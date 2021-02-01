using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public interface ILockAPI : ITTLockCloudAPI
    {
        /// <summary>
        /// Lock to work with.
        /// </summary>
        /// <exception cref="InvalidOperationException">Wasn't initialized.</exception>
        /// <exception cref="ArgumentNullException"/>
        Lock LockToOperate { get; set; }

        /// <summary>
        /// Open lock using gateway.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task OpenLock();

        /// <summary>
        /// Close lock using gateway.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task CloseLock();

        /// <summary>
        /// Freeze lock using gateway.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task FreezeLock();

        /// <summary>
        /// Unfreeze lock using gateway.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task UnfreezeLock();

        /// <summary>
        /// Change lock alias.
        /// </summary>
        /// <param name="newAlias"></param>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task ChangeLockAlias(string newAlias);

        /// <summary>
        /// Change lock super pass code.
        /// </summary>
        /// <param name="newPasscode"></param>
        /// <param name="modificationWay"></param>
        /// <returns></returns>
        /// <remarks>Super pass code can be entered on the keypad to unlock.</remarks>
        /// <exception cref="ArgumentException">
        /// <paramref name="newPasscode"/> is invalid
        /// -or-
        /// <paramref name="modificationWay"/> is invalid
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task ChangeLockSuperPasscode(string newPasscode, LockModificationWay modificationWay);

        /// <summary>
        /// Update lock passage mode config.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="modificationWay">Only <see cref="LockModificationWay.PhoneBluetooth"/> or <see cref="LockModificationWay.Gateway"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="modificationWay"/> is invalid</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task UpdateLockPassageModeConfig(PassageModeConfig config, LockModificationWay modificationWay);

        /// <summary>
        /// Delete all lock EKeys.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task DeleteAllLockEKeys();

        /// <summary>
        /// Delete lock from user.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task DeleteLock();

        /// <summary>
        /// Get lock battery level.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<LockBatteryLevelResult> GetLockBatteryLevel();

        /// <summary>
        /// Get full lock details.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<LockFullInfo> GetLockDetails();

        /// <summary>
        /// Get lock EKeys.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PageResult<EKeyInfo>> GetLockEKeys(int page = 1, int pageSize = 20);

        /// <summary>
        /// Get lock passage mode config.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PassageModeConfig> GetLockPassageModeConfig();

        /// <summary>
        /// Get lock pass codes.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PageResult<UserPasscode>> GetLockPasscodes(int page = 1, int pageSize = 20);

        /// <summary>
        /// Get lock pass code version.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PasscodeVersionResult> GetLockPasscodeVersion();

        /// <summary>
        /// Get user locks.
        /// </summary>
        /// <param name="lockAlias">Search by lock alias, fuzzy matching. Null if no filter.</param>
        /// <param name="lockTypeToSearch"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="lockTypeToSearch"/> is unknown.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PageResult<UserLock>> GetUserLocks(string lockAlias = null, DeviceType lockTypeToSearch = DeviceType.Lock, int page = 1, int pageSize = 20);

        /// <summary>
        /// Initialize lock.
        /// </summary>
        /// <param name="lockData"></param>
        /// <param name="lockAlias"></param>
        /// <param name="nb_IoT_isInitialized"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="lockData"/> is invalid
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<LockInitResult> InitLock(string lockData, string lockAlias, bool nb_IoT_isInitialized);

        /// <summary>
        /// Invalidate all EKeys (except admin's).
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task ResetAllLockEKeys();

        /// <summary>
        /// Set sector that lock will be able to read from IC card.
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="sector"/> is negative or greater than 15
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task SetLockHotelCardSector(int sector);

        /// <summary>
        /// Transfer current lock to new user.
        /// </summary>
        /// <param name="receiverUsername"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="receiverUsername"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task TransferLock(string receiverUsername);

        /// <summary>
        /// Transfer locks to new user.
        /// </summary>
        /// <param name="receiverUsername"></param>
        /// <param name="locksIds"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="receiverUsername"/> is invalid
        /// -or-
        /// <paramref name="locksIds"/> is empty
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task TransferLocks(string receiverUsername, int[] locksIds);

        /// <summary>
        /// Update lock auto-locking period.
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="modificationWay">Only <see cref="LockModificationWay.PhoneBluetooth"/> or <see cref="LockModificationWay.Gateway"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="seconds"/> is negative
        /// -or-
        /// <paramref name="modificationWay"/> is invalid.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task UpdateLockAutolockingTime(int seconds, LockModificationWay modificationWay);

        /// <summary>
        /// Update lock characteristic value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task UpdateLockCharacteristicValue(int value);

        /// <summary>
        /// Update lock data.
        /// </summary>
        /// <param name="newLockData"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="newLockData"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task UpdateLockData(string newLockData);

        /// <summary>
        /// Update lock battery level.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task UpdateLockBatterLevel(int value);

        /// <summary>
        /// Check if there is any upgrades for lock.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<LockUpgradeCheckResult> CheckForLockUpgrades();

        /// <summary>
        /// Recheck if there is any upgrades for lock.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="firmwareInfo"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or
        /// <see cref="LockToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<LockUpgradeCheckResult> RecheckForLockUpgrades(string firmwareInfo);
    }
}