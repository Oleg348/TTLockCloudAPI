namespace OrbitaTech.TTLock
{
    public class LockUpgradeCheckResult
    {
        public LockUpgradeCheckResult(LockUpgradeStatus upgradeStaus , string firmwareInfo, string firmwarePackage, string version)
        {
            UpgradeStaus = upgradeStaus;
            FirmwareInfo = firmwareInfo;
            FirmwarePackage = firmwarePackage;
            Version = version;
        }

        public LockUpgradeStatus UpgradeStaus { get; }

        public string FirmwareInfo { get; }

        public string FirmwarePackage { get; }

        public string Version { get; }
    }
}
