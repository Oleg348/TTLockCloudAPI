using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public interface IAuthenticationAPI : ITTLockCloudAPI
    {
        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="md5UserPassword"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="username"/> is null or empty
        /// -or-
        /// <paramref name="md5UserPassword"/> is null or empty or contains not 32 chars
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<User> Authenticate(string username, string md5UserPassword);

        /// <summary>
        /// Refresh authentication info.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns>New authentication info.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="refreshToken"/> is null or empty
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<AuthenticationInfo> RefreshAuthentication(string refreshToken);
    }
}
