namespace OrbitaTech.TTLock
{
    internal class UserLockDto
    {
        public int lockId { get; set; }

        /// <summary>
        /// Lock initialize time.
        /// </summary>
        public long date { get; set; }

        public string lockName { get; set; }

        public string lockAlias { get; set; }

        public string lockMac { get; set; }

        /// <summary>
        /// Lock battery level.
        /// </summary>
        public int electricQuantity { get; set; }

        public int keyboardPwdVersion { get; set; }

        /// <summary>
        /// Characteristic value. it is used to indicate what kinds of feature do a lock support.
        /// </summary>
        public int specialValue { get; set; }

        public int hasGateway { get; set; }

        /// <summary>
        /// Lock data, used to operate lock.
        /// </summary>
        public string lockData { get; set; }
    }
}
