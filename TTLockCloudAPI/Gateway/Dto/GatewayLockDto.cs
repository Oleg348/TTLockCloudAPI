namespace OrbitaTech.TTLock
{
    public class GatewayLockDto
    {
        public int lockId { get; set; }

        public string lockMac { get; set; }

        public string lockName { get; set; }

        public string lockAlias { get; set; }

        public int rssi { get; set; }

        public long updateDate { get; set; }
    }
}
