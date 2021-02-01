using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public interface IICCardAPI
    {
        /// <summary>
        /// IC card to operate.
        /// </summary>
        /// <exception cref="InvalidOperationException">Wasn't set.</exception>
        /// <exception cref="ArgumentNullException"/>
        ICCard ICCardToOperate { get; set; }

        /// <summary>
        /// Add new IC card.
        /// </summary>
        /// <param name="lockId"></param>
        /// <param name="data"></param>
        /// <param name="modificationWay"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="modificationWay"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException"><see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set.</exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<ICCard> AddICCard(int lockId, NewICCardData data, LockModificationWay modificationWay);

        /// <summary>
        /// Change IC card validity period.
        /// </summary>
        /// <param name="beginningTime"></param>
        /// <param name="expirationTime"></param>
        /// <param name="modificationWay"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="modificationWay"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="ICCardToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task ChangeICCardValidityPeriod(DateTime? beginningTime, DateTime? expirationTime, LockModificationWay modificationWay);

        /// <summary>
        /// Clear all IC cards of lock.
        /// </summary>
        /// <param name="lockId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"><see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set.</exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task ClearAllLockICCards(int lockId);

        /// <summary>
        /// Delete IC card.
        /// </summary>
        /// <param name="modificationWay"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="modificationWay"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="ICCardToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task DeleteICCard(LockModificationWay modificationWay);

        /// <summary>
        /// Get all IC cards.
        /// </summary>
        /// <param name="lockId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PageResult<UserICCard>> GetAllICCards(int lockId, int page = 1, int pageSize = 20);
    }
}