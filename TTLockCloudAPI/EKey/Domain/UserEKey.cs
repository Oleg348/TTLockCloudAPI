using System;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class UserEKey : EKey
    {
        public UserEKey(
            int id,
            UserType userType,
            EKeyStatus status,
            DateTime beginningTime,
            DateTime expirationTime,
            bool isAuthorized,
            bool isRemoteUnlockEnabled,
            int lockId,
            string lockData,
            string lockMacAddress,
            string lockName,
            string lockAlias,
            string lockSuperPasscode,
            int lockBatterLevel,
            LockVersion lockVersion,
            int lockPasscodeVersion,
            int lockCharacteristicValue,
            string remarks = null
        )
            : base(id)
        {
            UserType = userType.IsExist();
            Status = status.IsExist();
            BeginningTime = beginningTime;
            ExpirationTime = expirationTime;
            IsAuthorized = isAuthorized;
            IsRemoteUnlockEnabled = isRemoteUnlockEnabled;
            LockId = lockId;
            LockData = VerifyLockData(lockData);
            LockMacAddress = VerifyMacAddress(lockMacAddress);
            LockName = lockName;
            LockAlias = lockAlias;
            LockSuperPasscode = VerifyPasscode(lockSuperPasscode);
            LockBatterLevel = lockBatterLevel;
            LockVersion = lockVersion.IsNotNull(nameof(LockVersion));
            LockPasscodeVersion = lockPasscodeVersion;
            LockCharacteristicValue = lockCharacteristicValue;
            Remarks = remarks;
        }

        public UserType UserType { get; }

        public EKeyStatus Status { get; }

        public DateTime BeginningTime { get; }

        public DateTime ExpirationTime { get; }

        public bool IsAuthorized { get; }

        public bool IsRemoteUnlockEnabled { get; }

        public int LockId { get; }

        public string LockData { get; }

        public string LockMacAddress { get; }

        public string LockName { get; }

        public string LockAlias { get; }

        public string LockSuperPasscode { get; }

        public int LockBatterLevel { get; }

        public LockVersion LockVersion { get; }

        public int LockPasscodeVersion { get; }

        public int LockCharacteristicValue { get; }

        public string Remarks { get; }
    }
}
