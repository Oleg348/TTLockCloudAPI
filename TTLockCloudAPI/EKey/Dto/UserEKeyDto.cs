namespace OrbitaTech.TTLock
{
    internal class UserEKeyDto
    {
        public int keyId { get; set; }

        public string lockData { get; set; }

        public int lockId { get; set; }

        /// <summary>
        /// EKey type: "110301" - admin EKey, "110302" - common user EKey.
        /// </summary>
        public string userType { get; set; }

        /// <summary>
        /// <list type="table">
        /// <listheader>values</listheader>
        /// <item> "110401"	- Normal</item>
        /// <item> "110402"	- Receiving</item>
        /// <item> "110405"	- Frozen</item>
        /// <item> "110408"	- Deleted</item>
        /// <item> "110410"	- Reset</item>
        /// </list>
        /// </summary>
        public string keyStatus { get; set; }

        public string lockName { get; set; }

        public string lockAlias { get; set; }

        public string lockMac { get; set; }

        public string noKeyPwd { get; set; }

        public int electricQuantity { get; set; }

        public LockVersionDto lockVersion { get; set; }

        /// <summary>
        /// The time when it becomes valid.
        /// </summary>
        public long startDate { get; set; }

        /// <summary>
        /// The time when it is expired.
        /// </summary>
        public long endDate { get; set; }

        public string remarks { get; set; }

        /// <summary>
        /// Is key authorized: 0 - NO, 1 - yes.
        /// </summary>
        public int keyRight { get; set; }

        /// <summary>
        /// Pass code version: 0, 1, 2, 3, 4.
        /// </summary>
        public int keyboardPwdVersion { get; set; }

        /// <summary>
        /// Characteristic value. it is used to indicate what kinds of feature do a lock support.
        /// </summary>
        public int specialValue { get; set; }

        /// <summary>
        /// Is remote unlock enabled: 1 - yes, 2 - no.
        /// </summary>
        public int remoteEnable { get; set; }
    }
}
