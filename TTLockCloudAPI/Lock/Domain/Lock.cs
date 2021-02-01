using System;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class Lock
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="macAddress"></param>
        /// <param name="data"></param>
        /// <exception cref="ArgumentException">
        /// <paramref name="macAddress"/> is invalid
        /// -or-
        /// <paramref name="data"/> is invalid
        /// </exception>
        public Lock(int id, string macAddress, string data)
        {
            Id = id;
            MacAddress = VerifyMacAddress(macAddress);
            Data = VerifyLockData(data);
        }

        public int Id { get; }

        public string MacAddress { get; }

        public string Data { get; }
    }
}
