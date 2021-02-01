using System;

namespace OrbitaTech.TTLock
{
    public class UserRegistrationResult
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="username"></param>
        /// <exception cref="ArgumentException"><paramref name="username"/> is null or empty.</exception>
        public UserRegistrationResult(string username)
        {
            UserName = username.IsNotNullOrEmpty(nameof(username));
        }

        public string UserName { get; }
    }
}
