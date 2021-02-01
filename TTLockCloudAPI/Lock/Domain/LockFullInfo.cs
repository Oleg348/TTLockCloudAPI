using System;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class LockFullInfo
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="macAddress"></param>
        /// <param name="initializeTime"></param>
        /// <param name="name"></param>
        /// <param name="alias"></param>
        /// <param name="version"></param>
        /// <param name="batteryLevel"></param>
        /// <param name="passwordKeyboardVersion"></param>
        /// <param name="characteristicValue"></param>
        /// <param name="keyData"></param>
        /// <param name="ekeyValidityFlag"></param>
        /// <param name="adminPasscode"></param>
        /// <param name="superPasscode"></param>
        /// <param name="aesKey"></param>
        /// <param name="utcTimeZoneOffset"></param>
        /// <param name="productModel"></param>
        /// <param name="hardwareRevision"></param>
        /// <param name="firmwareRevision"></param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="version"/> is null
        /// </exception>
        public LockFullInfo(
            int id,
            string macAddress,
            DateTime initializeTime,
            string name,
            string alias,
            LockVersion version,
            int batteryLevel,
            int passwordKeyboardVersion,
            int characteristicValue,
            string keyData,
            int ekeyValidityFlag,
            string adminPasscode,
            string superPasscode,
            string aesKey,
            long utcTimeZoneOffset,
            string productModel,
            string hardwareRevision,
            string firmwareRevision
        )
        {
            Id = id;
            MacAddress = VerifyMacAddress(macAddress);
            InitializeTime = initializeTime;
            Name = name;
            Alias = alias;
            Version = version.IsNotNull(nameof(version));
            BatteryLevel = batteryLevel;
            PasswordKeyboardVersion = passwordKeyboardVersion;
            CharacteristicValue = characteristicValue;
            KeyData = keyData;
            EKeyValidityFlag = ekeyValidityFlag;
            AdminPasscode = adminPasscode;
            SuperPasscode = superPasscode;
            AESKey = aesKey;
            UTCTimeZoneOffset = utcTimeZoneOffset;
            ProductModel = productModel;
            HardwareRevision = hardwareRevision;
            FirmwareRevision = firmwareRevision;
        }

        public int Id { get; }

        public string MacAddress { get; }

        public DateTime InitializeTime { get; }

        public string Name { get; }

        public string Alias { get; }

        public LockVersion Version { get; }

        public int BatteryLevel { get; }

        public int PasswordKeyboardVersion { get; }

        public int CharacteristicValue { get; }

        /// <summary>
        /// The key data which will be used to unlock.
        /// </summary>
        public string KeyData { get; }

        /// <summary>
        /// The flag which will be used to check the validity of the EKey.
        /// </summary>
        public int EKeyValidityFlag { get; }

        public string AdminPasscode { get; }

        public string SuperPasscode { get; }

        public string AESKey { get; }

        /// <summary>
        /// Lock time zone offset in milliseconds.
        /// </summary>
        public long UTCTimeZoneOffset { get; }

        public string ProductModel { get; }

        public string HardwareRevision { get; }

        public string FirmwareRevision { get; }
    }
}
