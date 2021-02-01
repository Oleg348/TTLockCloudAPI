using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public interface IUserAPI : ITTLockCloudAPI
    {
        /// <summary>
        /// Register new user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="md5Password"></param>
        /// <returns>Registered user name.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="username"/> is invalid
        /// -or-
        /// <paramref name="md5Password"/> is invalid
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<UserRegistrationResult> Register(string username, string md5Password);

        /// <summary>
        /// Get all the users registered in application.
        /// </summary>
        /// <param name="startDate">Null if no restrictions.</param>
        /// <param name="finishDate">Null if no restrictions.</param>
        /// <param name="page">Page to load.</param>
        /// <param name="pageSize">Items per page.</param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PageResult<UserRegistrationInfo>> GetAllUsers(DateTime? startDate, DateTime? finishDate, int page = 1, int pageSize = 20);

        /// <summary>
        /// Reset user's password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="md5Password"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="username"/> is invalid
        /// -or-
        /// <paramref name="md5Password"/> is invalid
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task ResetPassword(string username, string md5Password);

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task Delete(string username);
    }
}
