using System;

namespace OrbitaTech.TTLock
{
    public class UserRegistrationInfo
    {
        public UserRegistrationInfo(string userId, DateTime registrationTime)
        {
            UserId = userId;
            RegistrationTime = registrationTime;
        }

        public string UserId { get; }

        public DateTime RegistrationTime { get; }
    }
}
