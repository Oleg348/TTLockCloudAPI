using System;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class UserPasscode : Passcode
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lockId"></param>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="type"></param>
        /// <param name="beginningTime"></param>
        /// <param name="expirationTime"></param>
        /// <param name="sendTime"></param>
        /// <param name="senderUsername"></param>
        /// <param name="nb_IoT_Status"></param>
        /// <exception cref="ArgumentException">Pass code is invalid.</exception>
        public UserPasscode(
            int id,
            int lockId,
            string value,
            string name,
            int version,
            int type,
            DateTime beginningTime,
            DateTime expirationTime,
            DateTime sendTime,
            string senderUsername,
            int nb_IoT_Status
        )
            : base(id, lockId)
        {
            Value = VerifyPasscode(value);
            Name = name;
            Version = version;
            Type = type;
            BeginningTime = beginningTime;
            ExpirationTime = expirationTime;
            SendTime = sendTime;
            SenderUsername = senderUsername;
            NB_IoT_Status = nb_IoT_Status;
        }

        public string Value { get; }

        public string Name { get; }

        public int Version { get; }

        public int Type { get; }

        public DateTime BeginningTime { get; }

        public DateTime ExpirationTime { get; }

        public DateTime SendTime { get; }

        public string SenderUsername { get; }

        public int NB_IoT_Status { get; }
    }
}
