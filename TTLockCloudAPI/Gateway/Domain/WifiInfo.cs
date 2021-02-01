using System;

namespace OrbitaTech.TTLock
{
    public class WifiInfo
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="wifiName"></param>
        /// <exception cref="ArgumentNullException"/>
        public WifiInfo(string wifiName)
        {
            WifiName = wifiName.IsNotNull(nameof(wifiName));
        }

        public string WifiName { get; }
    }
}