using System;

namespace OrbitaTech.TTLock
{
    public class EKeyInfo
    {
        public EKeyInfo(
            int eKeyId,
            string eKeyName,
            string eKeyStatus,
            DateTime eKeyStartTime,
            DateTime eKeyExpirationTime,
            string eKeyRight,
            int lockId,
            int ownerOpenId,
            string ownerUsername,
            string senderUsername,
            string remarks,
            DateTime sendTime
        )
        {
            EKeyId = eKeyId;
            EKeyName = eKeyName;
            EKeyStatus = eKeyStatus;
            EKeyStartTime = eKeyStartTime;
            EKeyExpirationTime = eKeyExpirationTime;
            EKeyRight = eKeyRight;
            LockId = lockId;
            OwnerOpenId = ownerOpenId;
            OwnerUsername = ownerUsername;
            SenderUsername = senderUsername;
            Remarks = remarks;
            SendTime = sendTime;
        }

        public int EKeyId { get; }

        public string EKeyName { get; }

        public string EKeyStatus { get; }

        public DateTime EKeyStartTime { get; }

        public DateTime EKeyExpirationTime { get; }

        public string EKeyRight { get; }

        public int LockId { get; }

        public int OwnerOpenId { get; }

        public string OwnerUsername { get; }

        public string SenderUsername { get; }

        public string Remarks { get; }

        public DateTime SendTime { get; }
    }
}
