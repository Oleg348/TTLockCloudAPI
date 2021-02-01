namespace OrbitaTech.TTLock
{
    internal class LockUpgradeCheckResultDto
    {
        /// <summary>
        /// Is upgrading available: 0-No, 1-Yes, 2-Unknown
        /// </summary>
        public int needUpgrade { get; set; }

        public string firmwareInfo { get; set; }

        public string firmwarePackage { get; set; }

        /// <summary>
        /// Latest firmware version
        /// </summary>
        public string version { get; set; }
    }
}
