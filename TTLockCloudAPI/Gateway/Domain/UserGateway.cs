using System;

namespace OrbitaTech.TTLock
{
    public class UserGateway : Gateway
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="macAddress"></param>
        /// <param name="version"></param>
        /// <param name="networkName"></param>
        /// <param name="locksAmount"></param>
        /// <param name="isOnline"></param>
        /// <exception cref="ArgumentException"><paramref name="macAddress"/> is invalid.</exception>
        public UserGateway(
            int id, string macAddress,
            int version,
            string networkName,
            int locksAmount,
            bool isOnline
        )
            : base(id, macAddress)
        {
            Version = version;
            NetworkName = networkName;
            LocksAmount = locksAmount;
            IsOnline = isOnline;
        }

        public int Version { get; }

        public string NetworkName { get; }

        public int LocksAmount { get; }

        public bool IsOnline { get; }
    }
}
