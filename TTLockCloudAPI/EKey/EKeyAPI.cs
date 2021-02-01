using System;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public class EKeyAPI : TTLockCloudAPI, IEKeyAPI
    {
        private EKey _ekey;

        public EKeyAPI(Uri serverUri = null)
            : base("v3/key/", serverUri)
        { }

        public EKey EKeyToOperate
        {
            get => _ekey ?? throw Error.InvalidOperation("EKey wasn't set");
            set => _ekey = value.IsNotNull(nameof(value));
        }

        private static UserType __ParseUserType(string apiValue)
        {
            switch (apiValue)
            {
                case "110301":
                    return UserType.Admin;
                case "110302":
                    return UserType.Common;

                default:
                    throw Argument.Invalid("userType", $"Unknown user type api value ({apiValue})");
            }
        }

        private static EKeyStatus __ParseEKeyStatus(string apiValue)
        {
            switch (apiValue)
            {
                case "110401":
                    return EKeyStatus.Normal;
                case "110402":
                    return EKeyStatus.Receiving;
                case "110405":
                    return EKeyStatus.Frozen;
                case "110408":
                    return EKeyStatus.Deleted;
                case "110410":
                    return EKeyStatus.Reset;

                default:
                    throw Argument.Invalid("keyStatus", $"Unknown user type api value ({apiValue})");
            }
        }

        private static UserEKey __ParseEKeyDto(UserEKeyDto dto)
        {
            return new UserEKey(
                dto.keyId,
                __ParseUserType(dto.userType),
                __ParseEKeyStatus(dto.keyStatus),
                dto.startDate.GetDateTimeFromUnixMilliseconds(), dto.endDate.GetDateTimeFromUnixMilliseconds(),
                dto.keyRight == 1, dto.remoteEnable == 1,
                dto.lockId, dto.lockData, dto.lockMac, dto.lockName, dto.lockAlias, dto.noKeyPwd,
                dto.electricQuantity,
                dto.lockVersion.ToLockVersion(),
                dto.keyboardPwdVersion,
                dto.specialValue,
                dto.remarks
            );
        }

        public async Task<SendEKeyResult> SendEkey(NewEKeyData newEkeyData)
        {
            newEkeyData.IsNotNull(nameof(newEkeyData));

            var dto = await PostRequest<SendEKeyResultDto>("send",
                CreateDictionary(
                    "lockId", newEkeyData.LockId.ToString(),
                    "receiverUsername", newEkeyData.ReceiverUsername,
                    "keyName", newEkeyData.EKeyName,
                    "startDate", newEkeyData.BeginningTime.GetUnixTimeInMilliseconds().ToString(),
                    "endDate", newEkeyData.ExpirationTime.GetUnixTimeInMilliseconds().ToString(),
                    "remarks", newEkeyData.Remarks,
                    "remoteEnable", (newEkeyData.IsRemoteUnlockAllowed ? 1 : 2).ToString()
                )).ConfigureAwait(false);

            return new SendEKeyResult(dto.keyId);
        }

        public async Task<PageResult<UserEKey>> GetAllUserEKeys(string lockAlias = null, int page = 1, int pageSize = 20)
        {
            var requestParams = CreateDictionary(
                "pageNo", page.ToString(),
                "pageSize", pageSize.ToString()
            );
            if (!string.IsNullOrEmpty(lockAlias))
                requestParams.Add("lockAlias", lockAlias);

            var dto = await PostRequest<PageResultDto<UserEKeyDto>>(
                "list", requestParams).ConfigureAwait(false);

            return ConvertDto(() => dto.ToPageResult(__ParseEKeyDto));
        }

        public async Task<UserEKey> GetOneEkeyOfLock(int lockId)
        {
            var dto = await PostRequest<UserEKeyDto>("get",
                CreateDictionary(
                    "lockId", lockId.ToString()
                )
            ).ConfigureAwait(false);

            return ConvertDto(() => __ParseEKeyDto(dto));
        }

        public Task FreezeEKey()
        {
            return PostRequest("freeze",
                CreateDictionary(
                    "keyId", EKeyToOperate.Id.ToString()
                )
            );
        }

        public Task UnfreezeEKey()
        {
            return PostRequest("unfreeze",
                CreateDictionary(
                    "keyId", EKeyToOperate.Id.ToString()
                )
            );
        }

        public Task GrantAdminRightsToEKey(int lockId)
        {
            return PostRequest("authorize",
                CreateDictionary(
                    "keyId", EKeyToOperate.Id.ToString(),
                    "lockId", lockId.ToString()
                )
            );
        }

        public Task CancelAdminRightsToEKey(int lockId)
        {
            return PostRequest("unauthorize",
                CreateDictionary(
                    "keyId", EKeyToOperate.Id.ToString(),
                    "lockId", lockId.ToString()
                )
            );
        }

        public Task ChangeEKeyValidityTime(DateTime beginningTime, DateTime expirationTime)
        {
            return PostRequest("changePeriod",
                CreateDictionary(
                    "keyId", EKeyToOperate.Id.ToString(),
                    "startDate", beginningTime.GetUnixTimeInMilliseconds().ToString(),
                    "endDate", expirationTime.GetUnixTimeInMilliseconds().ToString()
                )
            );
        }

        public Task DeleteEKey()
        {
            return PostRequest("delete",
                CreateDictionary(
                    "keyId", EKeyToOperate.Id.ToString()
                )
            );
        }
    }
}
