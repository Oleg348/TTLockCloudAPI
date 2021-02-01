using System;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class UserICCard : ICCard
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
        /// <param name="status"></param>
        /// <param name="senderUsername"></param>
        /// <exception cref="ArgumentException">
        /// <paramref name="number"/> is invalid.
        /// </exception>
        public UserICCard(
            int id,
            int lockId,
            string number,
            string name,
            DateTime beginningTime,
            DateTime expirationTime,
            DateTime creationTime,
            ICCardStatus status,
            string senderUsername
        )
            : base(id, lockId)
        {
            Number = VerifyICCardNumber(number);
            Name = name;
            BeginningTime = beginningTime;
            ExpirationTime = expirationTime;
            CreationTime = creationTime;
            Status = status;
            SenderUsername = senderUsername;
        }

        public string Number { get; }

        public string Name { get; }

        public DateTime BeginningTime { get; }

        public DateTime ExpirationTime { get; }

        public DateTime CreationTime { get; }

        public ICCardStatus Status { get; }

        public string SenderUsername { get; }
    }
}
