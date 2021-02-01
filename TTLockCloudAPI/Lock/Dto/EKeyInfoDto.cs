namespace OrbitaTech.TTLock
{
    internal class EKeyInfoDto
    {
        /// <summary>
        /// EKey ID.
        /// </summary>
        public int keyId { get; set; }

        public int lockId { get; set; }

        /// <summary>
        /// Open id of an EKey owner.
        /// </summary>
        public int openid { get; set; }

        /// <summary>
        /// User name of an EKey owner.
        /// </summary>
        public string username { get; set; }

        public string keyName { get; set; }

        public string keyStatus { get; set; }

        /// <summary>
        /// The time when it becomes valid.
        /// </summary>
        public long startDate { get; set; }

        /// <summary>
        /// The time when it is expired.
        /// </summary>
        public long endDate { get; set; }

        /// <summary>
        /// Is key authorized:0-NO,1-yes.
        /// </summary>
        public string keyRight { get; set; }

        /// <summary>
        /// The sender's user name.
        /// </summary>
        public string senderUsername { get; set; }

        public string remarks { get; set; }

        /// <summary>
        /// Send time.
        /// </summary>
        public long date { get; set; }
    }
}
