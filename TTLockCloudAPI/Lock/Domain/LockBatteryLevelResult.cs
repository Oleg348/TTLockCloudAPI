namespace OrbitaTech.TTLock
{
    public class LockBatteryLevelResult
    {
        public LockBatteryLevelResult(int batteryLevel)
        {
            BatteryLevel = batteryLevel;
        }

        public int BatteryLevel { get; }
    }
}
