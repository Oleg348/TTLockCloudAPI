using System;

namespace OrbitaTech.TTLock
{
    public class GatewayLock
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mac"></param>
        /// <param name="name"></param>
        /// <param name="alias"></param>
        /// <param name="rssi"></param>
        /// <param name="rssiUpdateTime"></param>
        /// <exception cref="ArgumentException">
        /// <paramref name="mac"/> is invalid
        /// </exception>
        public GatewayLock(int id, string mac, string name, string alias, int rssi, DateTime rssiUpdateTime)
        {
            Id = id;
            Mac = APIHelpers.VerifyMacAddress(mac);
            Name = name;
            Alias = alias;
            RSSI = rssi;
            RSSIUpdateTime = rssiUpdateTime;
        }

        public int Id { get; }

        public string Mac { get; }

        public string Name { get; }

        public string Alias { get; set; }

        /// <summary>
        /// The signal intensity between gateway and lock.
        /// <list type="bullet">
        /// <listheader>Signal values.</listheader>
        /// <item>Greater than -75 is strong.</item>
        /// <item>[-85, -75] is medium</item>
        /// <item>Less than -85 is weak.</item>
        /// </list>
        /// </summary>
        public int RSSI { get; set; }

        public DateTime RSSIUpdateTime { get; set; }
    }
}
