using System;

namespace OrbitaTech.TTLock
{
    public class NewEKeyData
    {
        public NewEKeyData(
            int lockId,
            string receiverUsername,
            string eKeyName,
            DateTime beginningTime,
            DateTime expirationTime,
            string remarks = null,
            bool isRemoteUnlockAllowed = false
        )
        {
            LockId = lockId;
            ReceiverUsername = receiverUsername;
            EKeyName = eKeyName;
            BeginningTime = beginningTime;
            ExpirationTime = expirationTime;
            Remarks = remarks;
            IsRemoteUnlockAllowed = isRemoteUnlockAllowed;
        }

        public int LockId { get; }

        public string ReceiverUsername { get; }

        public string EKeyName { get; }

        public DateTime BeginningTime { get; }
        public DateTime ExpirationTime { get; }

        public string Remarks { get; set; }

        public bool IsRemoteUnlockAllowed { get; set; }
    }
}
