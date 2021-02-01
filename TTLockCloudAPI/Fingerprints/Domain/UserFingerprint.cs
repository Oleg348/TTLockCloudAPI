using System;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class UserFingerprint : Fingerprint
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lockId"></param>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="beginningTime"></param>
        /// <param name="expirationTime"></param>
        /// <param name="creationTime"></param>
        /// <param name="nB_IoT_Status"></param>
        /// <param name="senderUsername"></param>
        /// <exception cref="ArgumentException">
        /// <paramref name="number"/> is invalid.
        /// </exception>
        public UserFingerprint(
            int id,
            int lockId,
            string number,
            string name,
            DateTime beginningTime,
            DateTime expirationTime,
            DateTime creationTime,
            NB_IoT_OperateStatus nB_IoT_Status,
            string senderUsername
        )
            : base(id, lockId)
        {
            Number = VerifyFingerprintNumber(number);
            Name = name;
            BeginningTime = beginningTime;
            ExpirationTime = expirationTime;
            CreationTime = creationTime;
            NB_IoT_Status = nB_IoT_Status;
            SenderUsername = senderUsername;
        }

        public string Number { get; }

        public string Name { get; }

        public DateTime BeginningTime { get; }

        public DateTime ExpirationTime { get; }

        public DateTime CreationTime { get; }

        public NB_IoT_OperateStatus NB_IoT_Status { get; }

        public string SenderUsername { get; }
    }
}
