namespace OrbitaTech.TTLock
{
    internal class GatewayDto
    {
        public int gatewayId { get; set; }

        public string gatewayMac { get; set; }
    }

    internal class UserGatewayDto : GatewayDto
    {
        public int gatewayVersion { get; set; }

        public string networkName { get; set; }

        public int lockNum { get; set; }

        public int isOnline { get; set; }
    }

    internal class LockGatewayDto : GatewayDto
    {
        public int rssi { get; set; }

        public long rssiUpdateDate { get; set; }
    }
}
