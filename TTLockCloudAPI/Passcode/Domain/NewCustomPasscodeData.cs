using System;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class NewCustomPasscodeData
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="passcode"></param>
        /// <param name="passcodeName"></param>
        /// <param name="beginningTime"></param>
        /// <param name="expirationTime"></param>
        /// <exception cref="ArgumentException">
        /// <paramref name="passcode"/> is invalid
        /// -or-
        /// <paramref name="passcodeName"/> is empty.
        /// </exception>
        public NewCustomPasscodeData(string passcode, string passcodeName, DateTime beginningTime, DateTime expirationTime)
        {
            Passcode = VerifyPasscode(passcode);
            PasscodeName = passcodeName.IsNotNullOrEmpty(nameof(passcodeName));
            BeginningTime = beginningTime;
            ExpirationTime = expirationTime;
        }

        public string Passcode { get; }

        public string PasscodeName { get; }

        public DateTime BeginningTime { get; }

        public DateTime ExpirationTime { get; }
    }
}
