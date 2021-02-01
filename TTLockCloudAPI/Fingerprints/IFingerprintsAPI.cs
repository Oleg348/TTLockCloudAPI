using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public interface IFingerprintsAPI : ITTLockCloudAPI
    {
        /// <summary>
        /// Fingerprint to operate.
        /// </summary>
        /// <exception cref="InvalidOperationException">Wasn't set.</exception>
        /// <exception cref="ArgumentNullException"/>
        Fingerprint FingerprintToOperate { get; set; }

        /// <summary>
        /// Add finger print to lock.
        /// </summary>
        /// <param name="lockId"></param>
        /// <param name="fingerprintNumber"></param>
        /// <param name="fingerprintName"></param>
        /// <param name="beginningTime"></param>
        /// <param name="expirationTime"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="fingerprintNumber"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException"><see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set.</exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<Fingerprint> AddFingerprint(
            int lockId,
            string fingerprintNumber,
            string fingerprintName = null,
            DateTime? beginningTime = null,
            DateTime? expirationTime = null
        );

        /// <summary>
        /// Change fingerprint validity period.
        /// </summary>
        /// <param name="newBeginningTime"></param>
        /// <param name="newExpirationTime"></param>
        /// <param name="modificationWay"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="modificationWay"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="FingerprintToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task ChangeFingerprintValidityPeriod(DateTime newBeginningTime, DateTime newExpirationTime, LockModificationWay modificationWay);

        /// <summary>
        /// Delete all the lock's fingerprints.
        /// </summary>
        /// <param name="lockId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set.
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task DeleteAllTheLockFingerprints(int lockId);

        /// <summary>
        /// Delete current fingerprint.
        /// </summary>
        /// <param name="modificationWay"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="modificationWay"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set
        /// -or-
        /// <see cref="FingerprintToOperate"/> wasn't set
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task DeleteFingerprint(LockModificationWay modificationWay);

        /// <summary>
        /// Get all the lock's fingerprints.
        /// </summary>
        /// <param name="lockId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't set.
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PageResult<UserFingerprint>> GetAllFingerprints(int lockId, int page = 1, int pageSize = 20);
    }
}