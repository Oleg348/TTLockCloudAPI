using System;

namespace OrbitaTech.TTLock
{
    public class NewGeneratedPasscodeData
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="passcodeVersion"></param>
        /// <param name="passcodeType"></param>
        /// <param name="passcodeName"></param>
        /// <param name="beginningTime"></param>
        /// <param name="expirationTime"></param>
        /// <exception cref="ArgumentException">
        /// <paramref name="passcodeName"/> is null or empty
        /// -or-
        /// <paramref name="passcodeType"/> is invalid
        /// </exception>
        public NewGeneratedPasscodeData(int passcodeVersion, PasscodeType passcodeType, string passcodeName, DateTime beginningTime, DateTime expirationTime)
        {
            PasscodeVersion = passcodeVersion;
            PasscodeType = passcodeType.IsExist();
            PasscodeName = passcodeName.IsNotNullOrEmpty(nameof(passcodeName));
            BeginningTime = beginningTime;
            ExpirationTime = expirationTime;
        }

        public int PasscodeVersion { get; }

        public PasscodeType PasscodeType { get; }

        public string PasscodeName { get; }

        public DateTime BeginningTime { get; }

        public DateTime ExpirationTime { get; }
    }
}
