using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public interface IEKeyAPI : ITTLockCloudAPI
    {
        /// <summary>
        /// EKey to operate.
        /// </summary>
        /// <exception cref="InvalidOperationException">Value wasn't set.</exception>
        /// <exception cref="ArgumentNullException"/>
        EKey EKeyToOperate { get; set; }

        /// <summary>
        /// Send EKey to other user.
        /// </summary>
        /// <param name="newEkeyData"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"><see cref="UserToOperate"/> wasn't set</exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<SendEKeyResult> SendEkey(NewEKeyData newEkeyData);

        /// <summary>
        /// Get all user's EKeys.
        /// </summary>
        /// <param name="lockAlias"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"><see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set</exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PageResult<UserEKey>> GetAllUserEKeys(string lockAlias = null, int page = 1, int pageSize = 20);

        /// <summary>
        /// Get one user's EKey for lock.
        /// </summary>
        /// <param name="lockId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"><see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set</exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<UserEKey> GetOneEkeyOfLock(int lockId);

        /// <summary>
        /// Cancel admin rights for lock for current EKey.
        /// </summary>
        /// <param name="lockId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="EKeyToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task CancelAdminRightsToEKey(int lockId);

        /// <summary>
        /// Grant current EKey admin rights for lock.
        /// </summary>
        /// <param name="lockId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="EKeyToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task GrantAdminRightsToEKey(int lockId);

        /// <summary>
        /// Change validity time of EKey.
        /// </summary>
        /// <param name="beginningTime"></param>
        /// <param name="expirationTime"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="EKeyToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task ChangeEKeyValidityTime(DateTime beginningTime, DateTime expirationTime);

        /// <summary>
        /// Freeze EKey.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="EKeyToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task FreezeEKey();

        /// <summary>
        /// Unfreeze EKey.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="EKeyToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task UnfreezeEKey();

        /// <summary>
        /// Delete EKey.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="EKeyToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task DeleteEKey();
    }
}