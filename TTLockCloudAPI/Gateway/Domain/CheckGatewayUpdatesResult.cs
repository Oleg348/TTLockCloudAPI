namespace OrbitaTech.TTLock
{
    public class CheckGatewayUpdatesResult
    {
        public CheckGatewayUpdatesResult(bool needUpdate, string firmwareInfo)
        {
            NeedUpdate = needUpdate;
            FirmwareInfo = firmwareInfo;
        }

        public bool NeedUpdate { get; }

        public string FirmwareInfo { get; }
    }
}
