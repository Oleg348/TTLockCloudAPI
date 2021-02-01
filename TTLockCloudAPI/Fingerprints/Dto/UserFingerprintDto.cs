namespace OrbitaTech.TTLock
{
    internal class UserFingerprintDto
    {
        public int fingerprintId { get; set; }

        public int lockId { get; set; }

        /// <summary>
        /// Fingerprint code.
        /// </summary>
        public string fingerprintNumber { get; set; }

        public string fingerprintName { get; set; }

        /// <summary>
        /// The time when it becomes valid.
        /// </summary>
        public long startDate { get; set; }

        /// <summary>
        /// The time when it is expired.
        /// </summary>
        public long endDate { get; set; }

        /// <summary>
        /// Create time.
        /// </summary>
        public long createDate { get; set; }

        /// <summary>
        /// NB-IoT operate status.
        /// <list type="bullet">
        /// <item> 1 - normal</item>
        /// <item> 2 - invalid or expired</item>
        /// <item> 3 - pending</item>
        /// <item> 4 - adding</item>
        /// <item> 5 - add failed</item>
        /// <item> 6 - modifying</item>
        /// <item> 7 - modify failed</item>
        /// <item> 8 - deleting</item>
        /// <item> 9 - delete failed</item>
        /// </list>
        /// </summary>
        public int status { get; set; }

        public string senderUsername { get; set; }
    }
}
