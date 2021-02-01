using System;

namespace OrbitaTech.TTLock
{
    public class UserLock : Lock
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="macAddress"></param>
        /// <param name="data"></param>
        /// <param name="initializeTime"></param>
        /// <param name="name"></param>
        /// <param name="alias"></param>
        /// <param name="batteryLevel"></param>
        /// <param name="passwordKeyboardVersion"></param>
        /// <param name="characteristicValue"></param>
        /// <param name="hasGateway"></param>
        /// <exception cref="ArgumentException">
        /// <paramref name="macAddress"/> is invalid
        /// -or-
        /// <paramref name="data"/> is invalid
        /// </exception>
        public UserLock(
            int id,
            string macAddress,
            string data,
            DateTime initializeTime,
            string name,
            string alias,
            int batteryLevel,
            int passwordKeyboardVersion,
            int characteristicValue,
            bool hasGateway
        )
            : base(id, macAddress, data)
        {
            InitializeTime = initializeTime;
            Name = name;
            Alias = alias;
            BatteryLevel = batteryLevel;
            PasswordKeyboardVersion = passwordKeyboardVersion;
            CharacteristicValue = characteristicValue;
            HasGateway = hasGateway;
        }

        public DateTime InitializeTime { get; }

        public string Name { get; }

        public string Alias { get; }

        public int BatteryLevel { get; }

        public int PasswordKeyboardVersion { get; }

        public int CharacteristicValue { get; }

        public bool HasGateway { get; }
    }
}
