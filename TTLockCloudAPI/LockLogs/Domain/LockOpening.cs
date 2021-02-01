using System;

namespace OrbitaTech.TTLock
{
    public class LockOpening
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="lockId"></param>
        /// <param name="isSuccess"></param>
        /// <param name="userThatOpened"></param>
        /// <param name="entityType"></param>
        /// <param name="entityCode"></param>
        /// <param name="lockTime"></param>
        /// <param name="serverTime"></param>
        public LockOpening(
            int lockId,
            bool isSuccess,
            string userThatOpened,
            OpeningEntityType entityType,
            string entityCode,
            DateTime lockTime,
            DateTime serverTime
        )
        {
            LockId = lockId;
            IsSuccess = isSuccess;
            UserThatOpened = userThatOpened;
            EntityType = entityType;
            EntityCode = entityCode;
            LockTime = lockTime;
            ServerTime = serverTime;
        }

        public int LockId { get; }

        public bool IsSuccess { get; }

        public string UserThatOpened { get; }

        public OpeningEntityType EntityType { get; }

        /// <summary>
        /// Pass code, IC card number, or wristband address.
        /// </summary>
        public string EntityCode { get; }

        public DateTime LockTime { get; }

        public DateTime ServerTime { get; }
    }
}
