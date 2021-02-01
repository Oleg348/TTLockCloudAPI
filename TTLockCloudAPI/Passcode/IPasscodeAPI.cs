using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public interface IPasscodeAPI : ITTLockCloudAPI
    {
        /// <summary>
        /// Pass code to work with.
        /// </summary>
        /// <exception cref="InvalidOperationException">Wasn't set.</exception>
        /// <exception cref="ArgumentNullException"/>
        Passcode PasscodeToOperate { get; set; }

        /// <summary>
        /// Add custom pass code.
        /// </summary>
        /// <param name="lockId"></param>
        /// <param name="data"></param>
        /// <param name="modificationWay"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="modificationWay"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<CustomPasscode> AddCustomPasscode(int lockId, NewCustomPasscodeData data, LockModificationWay modificationWay);

        /// <summary>
        /// Change pass code parameters.
        /// </summary>
        /// <param name="newValue">Null or empty to not modify.</param>
        /// <param name="newBeginningTime">Null or empty to not modify.</param>
        /// <param name="newExpirationTime">Null or empty to not modify.</param>
        /// <param name="modificationWay"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="modificationWay"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="PasscodeToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task ChangePasscode(string newValue, DateTime? newBeginningTime, DateTime? newExpirationTime, LockModificationWay modificationWay);

        /// <summary>
        /// Delete pass code.
        /// </summary>
        /// <param name="modificationWay"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="modificationWay"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="PasscodeToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task DeletePasscode(LockModificationWay modificationWay);

        /// <summary>
        /// Generate new pass code.
        /// </summary>
        /// <param name="lockId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<GeneratedPasscode> GeneratePasscode(int lockId, NewGeneratedPasscodeData data);
    }
}
