namespace OrbitaTech.TTLock
{
    internal class PasscodeDto
    {
        /// <summary>
        /// Pass code ID.
        /// </summary>
        public int keyboardPwdId { get; set; }

        public int lockId { get; set; }

        /// <summary>
        /// Pass code.
        /// </summary>
        public string keyboardPwd { get; set; }

        /// <summary>
        /// Pass code name.
        /// </summary>
        public string keyboardPwdName { get; set; }

        /// <summary>
        /// Pass code version.
        /// </summary>
        public int keyboardPwdVersion  { get; set; }

        /// <summary>
        /// Pass code type.
        /// </summary>
        public int keyboardPwdType { get; set; }

        /// <summary>
        /// The time when it becomes valid.
        /// </summary>
        public long startDate   { get; set; }

        /// <summary>
        /// The time when it is expired
        /// </summary>
        public long endDate { get; set; }

        /// <summary>
        /// Send time.
        /// </summary>
        public long sendDate    { get; set; }

        /// <summary>
        /// NB-IoT operate status:1-normal, 2-invalid or expired, 3-pending, 4-adding, 5-add failed, 6-modifying, 7-modify failed, 8-deleting, 9-delete failed
        /// </summary>
        public int status  { get; set; }

        public string senderUsername { get; set; }
    }
}
