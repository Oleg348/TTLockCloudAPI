using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public interface ILockLogsAPI : ITTLockCloudAPI
    {
        /// <summary>
        /// Get lock's openings.
        /// </summary>
        /// <param name="lockId"></param>
        /// <param name="from"></param>
        /// <param name="until"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"><see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set.</exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PageResult<LockOpening>> GetLockOpenings(int lockId, DateTime? from = null, DateTime? until = null, int page = 1, int pageSize = 20);

        /// <summary>
        /// Upload lock's openings.
        /// </summary>
        /// <param name="lockId"></param>
        /// <param name="openings">Openings string that you get from SDK.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="openings"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException"><see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set.</exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task UploadLockOpenings(int lockId, string openings);
    }
}