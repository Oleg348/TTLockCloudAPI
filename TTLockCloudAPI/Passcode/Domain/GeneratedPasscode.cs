using System;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class GeneratedPasscode : Passcode
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"><paramref name="value"/> is invalid.</exception>
        public GeneratedPasscode(int id, int lockId, string value)
            : base(id, lockId)
        {
            Value = VerifyPasscode(value);
        }

        public string Value { get; }
    }
}
