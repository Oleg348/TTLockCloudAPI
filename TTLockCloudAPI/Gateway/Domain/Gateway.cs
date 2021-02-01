using System;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class Gateway
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="macAddress"></param>
        /// <exception cref="ArgumentException"><paramref name="macAddress"/> is invalid.</exception>
        public Gateway(int id, string macAddress)
        {
            Id = id;
            MacAddress = VerifyMacAddress(macAddress);
        }

        public int Id { get; }

        public string MacAddress { get; }
    }
}
