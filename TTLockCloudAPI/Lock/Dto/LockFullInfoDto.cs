namespace OrbitaTech.TTLock
{
    internal class LockFullInfoDto
    {
        public int lockId { get; set; }

        public string lockName { get; set; }

        public string lockAlias { get; set; }

        public string lockMac { get; set; }

        public string lockKey { get; set; }

        public int lockFlagPos { get; set; }

        public string adminPwd { get; set; }

        public string noKeyPwd { get; set; }

        public string deletePwd { get; set; }

        public string aesKeyStr { get; set; }

        public LockVersionDto lockVersion { get; set; }

        public int keyboardPwdVersion { get; set; }

        public int electricQuantity { get; set; }

        public int specialValue { get; set; }

        public long timezoneRawOffset { get; set; }

        public string modelNum { get; set; }

        public string hardwareRevision { get; set; }

        public string firmwareRevision { get; set; }

        public long date { get; set; }
    }
}
