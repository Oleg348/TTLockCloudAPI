namespace OrbitaTech.TTLock
{
    public class GatewayRouterModelInfo
    {
        public GatewayRouterModelInfo(string model, string hardwareRevision, string firmwareRevision)
        {
            Model = model;
            HardwareRevision = hardwareRevision;
            FirmwareRevision = firmwareRevision;
        }

        public string Model { get; }

        public string HardwareRevision { get; }

        public string FirmwareRevision { get; }
    }
}