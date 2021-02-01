using System;
using System.Collections.Generic;

namespace OrbitaTech.TTLock
{
    public class AuthenticationInfo
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="tokenExpirationTime"></param>
        /// <param name="refreshToken"></param>
        /// <param name="permissions"></param>
        /// <exception cref="ArgumentNullException"><paramref name="permissions"/> is null.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="accessToken"/> is null or empty
        /// -or-
        /// <paramref name="refreshToken"/> is null or empty
        /// </exception>
        public AuthenticationInfo(
            string accessToken,
            int tokenExpirationTime,
            string refreshToken,
            IReadOnlyList<string> permissions
        )
        {
            AccessToken = accessToken.IsValid(at => !string.IsNullOrEmpty(at), nameof(accessToken), "Access token can't be null or empty");
            AccessTokenValidityDuration = tokenExpirationTime;
            RefreshToken = refreshToken.IsValid(rt => !string.IsNullOrEmpty(rt), nameof(refreshToken), "Refresh token can't be null or empty");
            Permissions = permissions.IsNotNull(nameof(permissions));
        }

        public string AccessToken { get; }

        /// <summary>
        /// In seconds.
        /// </summary>
        public int AccessTokenValidityDuration { get; }

        public string RefreshToken { get; }

        public IReadOnlyList<string> Permissions { get; }
    }
}
