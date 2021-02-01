using System;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class LockAPI : TTLockCloudAPI, ILockAPI
    {
        private Lock _lock;

        public LockAPI(Uri serverUri = null)
            : base("v3/lock/", serverUri)
        { }

        public Lock LockToOperate
        {
            get => _lock ?? throw Error.InvalidOperation("Working lock wasn't initialized.");
            set => _lock = value.IsNotNull(nameof(value));
        }

        private static void __VerifyLockSettingsModificationWay(LockModificationWay modificationWay)
        {
            modificationWay.IsValid(
                w => w == LockModificationWay.PhoneBluetooth || w == LockModificationWay.Gateway,
                nameof(modificationWay), $"Modification way must be {LockModificationWay.PhoneBluetooth:g} or {LockModificationWay.Gateway:g}"
            );
        }

        private static LockUpgradeCheckResult __ConvertDto(LockUpgradeCheckResultDto dto)
        {
            return new LockUpgradeCheckResult(
                (LockUpgradeStatus)dto.needUpgrade,
                dto.firmwareInfo, dto.firmwarePackage,
                dto.version
            );
        }

        public async Task<LockInitResult> InitLock(string lockData, string lockAlias, bool nb_IoT_isInitialized)
        {
            VerifyLockData(lockData);

            var dto = await PostRequest<LockInitResultDto>("initialize",
                CreateDictionary(
                    "lockData", lockData,
                    "lockAlias", lockAlias,
                    "nbInitSuccess", (nb_IoT_isInitialized ? 1 : 0).ToString()
                )
            ).ConfigureAwait(false);

            return new LockInitResult(dto.lockId, dto.keyId);
        }

        public async Task<PageResult<UserLock>> GetUserLocks(
            string lockAlias = null, DeviceType lockTypeToSearch = DeviceType.Lock,
            int page = 1, int pageSize = 20
        )
        {
            lockTypeToSearch.IsValid(
                t => t == DeviceType.Lock || t == DeviceType.LiftController,
                nameof(lockTypeToSearch), $"Lock type must be either {DeviceType.Lock:g} or {DeviceType.LiftController:g}"
            );

            var requestData = CreateDictionary(
                "type", lockTypeToSearch.ToString("d"),
                "pageNo", page.ToString(),
                "pageSize", pageSize.ToString()
            );
            if (!string.IsNullOrEmpty(lockAlias))
                requestData.Add("lockAlias", lockAlias);

            var dto = await PostRequest<PageResultDto<UserLockDto>>(
                "list", requestData).ConfigureAwait(false);

            return ConvertDto(() => dto.ToPageResult(
                l => new UserLock(
                    l.lockId,
                    l.lockMac,
                    l.lockData,
                    l.date.GetDateTimeFromUnixMilliseconds(),
                    l.lockName,
                    l.lockAlias,
                    l.electricQuantity,
                    l.keyboardPwdVersion,
                    l.specialValue,
                    l.hasGateway != 0
                )
            ));
        }

        public Task OpenLock()
        {
            return PostRequest("unlock",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            );
        }

        public Task CloseLock()
        {
            return PostRequest("lock",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            );
        }

        public Task FreezeLock()
        {
            return PostRequest("freeze",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            );
        }

        public Task UnfreezeLock()
        {
            return PostRequest("unfreeze",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            );
        }

        public Task DeleteLock()
        {
            return PostRequest("delete",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            );
        }

        public Task TransferLocks(string receiverUsername, int[] locksIds)
        {
            VerifyUsername(receiverUsername);
            locksIds.IsValid(lids => lids?.Length > 0, nameof(locksIds), "Transferred locks ids array must be not empty");

            return PostRequest("transfer",
                CreateDictionary(
                    "receiverUsername", receiverUsername,
                    "lockIdList", locksIds.SerializeToJson()
                )
            );
        }

        public Task TransferLock(string receiverUsername)
        {
            return TransferLocks(receiverUsername, new[] { LockToOperate.Id });
        }

        public async Task<LockFullInfo> GetLockDetails()
        {
            var dto = await PostRequest<LockFullInfoDto>("detail",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            ).ConfigureAwait(false);

            return ConvertDto(() => new LockFullInfo(
                dto.lockId, dto.lockMac,
                dto.date.GetDateTimeFromUnixMilliseconds(),
                dto.lockName, dto.lockAlias,
                new LockVersion(
                    dto.lockVersion.protocolType, dto.lockVersion.protocolVersion,
                    dto.lockVersion.scene,
                    dto.lockVersion.groupId, dto.lockVersion.orgId
                ),
                dto.electricQuantity,
                dto.keyboardPwdVersion,
                dto.specialValue,
                dto.lockKey,
                dto.lockFlagPos,
                dto.adminPwd, dto.noKeyPwd,
                dto.aesKeyStr,
                dto.timezoneRawOffset,
                dto.modelNum, dto.hardwareRevision, dto.firmwareRevision
            ));
        }

        public async Task<PageResult<EKeyInfo>> GetLockEKeys(int page = 1, int pageSize = 20)
        {
            var dto = await PostRequest<PageResultDto<EKeyInfoDto>>("listKey",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString(),
                    "pageNo", page.ToString(),
                    "pageSize", pageSize.ToString()
                )
            ).ConfigureAwait(false);

            return ConvertDto(() => dto.ToPageResult(
                e => new EKeyInfo(
                    e.keyId, e.keyName, e.keyStatus,
                    e.startDate.GetDateTimeFromUnixMilliseconds(), e.endDate.GetDateTimeFromUnixMilliseconds(),
                    e.keyRight,
                    e.lockId,
                    e.openid, e.username,
                    e.senderUsername,
                    e.remarks,
                    e.date.GetDateTimeFromUnixMilliseconds()
                )
            ));
        }

        public Task DeleteAllLockEKeys()
        {
            return PostRequest("deleteAllKey",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            );
        }

        public Task ResetAllLockEKeys()
        {
            return PostRequest("resetKey",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            );
        }

        public async Task<PageResult<UserPasscode>> GetLockPasscodes(int page = 1, int pageSize = 20)
        {
            var dto = await PostRequest<PageResultDto<PasscodeDto>>("listKeyboardPwd",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString(),
                    "pageNo", page.ToString(),
                    "pageSize", pageSize.ToString()
                )
            ).ConfigureAwait(false);

            return ConvertDto(
                () => dto.ToPageResult(
                    p => new UserPasscode(
                        p.keyboardPwdId,
                        p.lockId,
                        p.keyboardPwd, p.keyboardPwdName, p.keyboardPwdVersion, p.keyboardPwdType,
                        p.startDate.GetDateTimeFromUnixMilliseconds(), p.endDate.GetDateTimeFromUnixMilliseconds(),
                        p.sendDate.GetDateTimeFromUnixMilliseconds(), p.senderUsername,
                        p.status
                    )
                )
            );
        }

        public async Task<PasscodeVersionResult> GetLockPasscodeVersion()
        {
            var dto = await PostRequest<PasscodeVersionResultDto>("getKeyboardPwdVersion",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            ).ConfigureAwait(false);

            return new PasscodeVersionResult(dto.keyboardPwdVersion);
        }

        public Task ChangeLockSuperPasscode(string newPasscode, LockModificationWay way)
        {
            VerifyPasscode(newPasscode);
            way.IsExist();

            return PostRequest("changeAdminKeyboardPwd",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString(),
                    "password", newPasscode,
                    "changeType", way.ToString("d")
                )
            );
        }

        public Task ChangeLockAlias(string newAlias)
        {
            return PostRequest("rename",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString(),
                    "lockAlias", newAlias
                )
            );
        }

        public Task UpdateLockBatterLevel(int value)
        {
            return PostRequest("updateElectricQuantity",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString(),
                    "electricQuantity", value.ToString()
                )
            );
        }

        public Task UpdateLockCharacteristicValue(int value)
        {
            return PostRequest("updateSpecialValue",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString(),
                    "specialValue", value.ToString()
                )
            );
        }

        public Task UpdateLockAutolockingTime(int seconds, LockModificationWay modificationWay)
        {
            seconds.IsValid(s => s >= 0, nameof(seconds), "Auto-locking time must be a positive value");
            __VerifyLockSettingsModificationWay(modificationWay);

            return PostRequest("setAutoLockTime",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString(),
                    "seconds", seconds.ToString(),
                    "type", modificationWay.ToString("d")
                )
            );
        }

        public Task UpdateLockData(string newLockData)
        {
            VerifyLockData(newLockData);

            return PostRequest("updateLockData",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString(),
                    "lockData", newLockData
                )
            );
        }

        public Task SetLockHotelCardSector(int sector)
        {
            sector.IsValid(s => s >= 0 && s < 16, nameof(sector), "Card sector must be >= 0 and < 16");

            return PostRequest("setHotelCardSector",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString(),
                    "sector", sector.ToString()
                )
            );
        }

        public Task UpdateLockPassageModeConfig(PassageModeConfig config, LockModificationWay modificationWay)
        {
            config.IsNotNull(nameof(config));
            __VerifyLockSettingsModificationWay(modificationWay);

            var requestParams = CreateDictionary(
                "lockId", LockToOperate.Id.ToString(),
                "passageMode", (config.IsEnabled ? 1 : 2).ToString(),
                "isAllDay", (config.IsAllDay ? 1 : 2).ToString(),
                "weekDays", config.WorkingDays.SerializeToJson(),
                "type", modificationWay.ToString("d")
            );
            if (!config.IsAllDay)
            {
                requestParams.Add("startDate", config.StartDayTime.ToString());
                requestParams.Add("endDate", config.EndDayTime.ToString());
            }

            return PostRequest("configPassageMode", requestParams);
        }

        public async Task<LockBatteryLevelResult> GetLockBatteryLevel()
        {
            var dto = await PostRequest<LockBatteryLevelResultDto>("queryElectricQuantity",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            ).ConfigureAwait(false);

            return new LockBatteryLevelResult(dto.electricQuantity);
        }

        public async Task<PassageModeConfig> GetLockPassageModeConfig()
        {
            var dto = await PostRequest<PassageModeConfigDto>("getPassageModeConfig",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            ).ConfigureAwait(false);

            var isEnabled = dto.passageMode == 1;
            var workingDays = dto.weekDays;
            var isAllDay = dto.isAllDay == 1;
            return ConvertDto(
                () => isAllDay
                    ? new PassageModeConfig(isEnabled, workingDays)
                    : new PassageModeConfig(isEnabled, dto.startDate, dto.endDate, workingDays)
            );
        }

        public async Task<LockUpgradeCheckResult> CheckForLockUpgrades()
        {
            var dto = await PostRequest<LockUpgradeCheckResultDto>("upgradeCheck",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString()
                )
            ).ConfigureAwait(false);

            return __ConvertDto(dto);
        }

        public async Task<LockUpgradeCheckResult> RecheckForLockUpgrades(string firmwareInfo)
        {
            firmwareInfo.IsNotNullOrEmpty(nameof(firmwareInfo));

            var dto = await PostRequest<LockUpgradeCheckResultDto>("upgradeRecheck",
                CreateDictionary(
                    "lockId", LockToOperate.Id.ToString(),
                    "firmwareInfo", firmwareInfo
                )
            ).ConfigureAwait(false);

            return __ConvertDto(dto);
        }
    }
}
