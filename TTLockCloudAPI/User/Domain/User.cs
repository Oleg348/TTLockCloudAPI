using System;
using System.Collections.Generic;

namespace OrbitaTech.TTLock
{
    public class User
    {
        private readonly AuthenticationInfo _authInfo;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authenticationInfo"></param>
        /// <exception cref="ArgumentNullException"><paramref name="authenticationInfo"/> is null</exception>
        public User(int id, AuthenticationInfo authenticationInfo)
        {
            Id = id;
            _authInfo = authenticationInfo.IsNotNull(nameof(authenticationInfo));
        }

        public int Id { get; }

        public string AccessToken => _authInfo.AccessToken;

        public int AccessTokenValidityDuration => _authInfo.AccessTokenValidityDuration;

        public string RefreshToken => _authInfo.RefreshToken;

        public IReadOnlyList<string> Permissions => _authInfo.Permissions;
    }
}
