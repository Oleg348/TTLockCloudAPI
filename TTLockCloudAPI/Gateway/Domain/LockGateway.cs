using System;

namespace OrbitaTech.TTLock
{
    public class LockGateway : Gateway
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="macAddress"></param>
        /// <param name="rssi"></param>
        /// <param name="rssiUpdateTime"></param>
        /// <exception cref="ArgumentException"><paramref name="macAddress"/> is invalid.</exception>
        public LockGateway(int id, string macAddress, int rssi, DateTime rssiUpdateTime)
            : base(id, macAddress)
        {
            RSSI = rssi;
            RSSIUpdateTime = rssiUpdateTime;
        }

        /// <summary>
        /// The signal intensity between gateway and lock.
        /// <list type="bullet">
        /// <listheader>Signal values.</listheader>
        /// <item>Greater than -75 is strong.</item>
        /// <item>[-85, -75] is medium</item>
        /// <item>Less than -85 is weak.</item>
        /// </list>
        /// </summary>
        public int RSSI { get; }

        public DateTime RSSIUpdateTime { get; }
    }
}
