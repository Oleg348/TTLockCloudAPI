using System;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public class FingerprintsAPI : TTLockCloudAPI, IFingerprintsAPI
    {
        private Fingerprint _fingerprint;

        public FingerprintsAPI(Uri serverUri = null)
            : base("v3/fingerprint/", serverUri)
        { }

        public Fingerprint FingerprintToOperate
        {
            get => _fingerprint ?? throw Error.InvalidOperation("Fingerprint wasn't set");
            set => _fingerprint = value.IsNotNull(nameof(FingerprintToOperate));
        }

        public async Task<PageResult<UserFingerprint>> GetAllFingerprints(int lockId, int page = 1, int pageSize = 20)
        {
            var dto = await PostRequest<PageResultDto<UserFingerprintDto>>("list",
                CreateDictionary(
                    "lockId", lockId.ToString(),
                    "pageNo", page.ToString(),
                    "pageSize", pageSize.ToString()
                )
            ).ConfigureAwait(false);

            return ConvertDto(
                () => dto.ToPageResult(
                    f => new UserFingerprint(
                        f.fingerprintId, f.lockId,
                        f.fingerprintNumber, f.fingerprintName,
                        f.startDate.GetDateTimeFromUnixMilliseconds(),
                        f.endDate.GetDateTimeFromUnixMilliseconds(),
                        f.createDate.GetDateTimeFromUnixMilliseconds(),
                        (NB_IoT_OperateStatus)f.status,
                        f.senderUsername
                    )
                )
            );
        }

        public async Task<Fingerprint> AddFingerprint(
            int lockId, string fingerprintNumber,
            string fingerprintName = null,
            DateTime? beginningTime = null, DateTime? expirationTime = null
        )
        {
            var requestData = CreateDictionary(
                "lockId", lockId.ToString(),
                "fingerprintNumber", fingerprintNumber
            );
            if (!string.IsNullOrEmpty(fingerprintName))
                requestData.Add("fingerprintName", fingerprintName);
            if (beginningTime != null)
                requestData.Add("startDate", beginningTime.Value.GetUnixTimeInMilliseconds().ToString());
            if (expirationTime != null)
                requestData.Add("endDate", expirationTime.Value.GetUnixTimeInMilliseconds().ToString());

            var dto = await PostRequest<AddFingerprintDto>(
                "add", requestData
            ).ConfigureAwait(false);

            return new Fingerprint(dto.fingerprintId, lockId);
        }

        public Task ChangeFingerprintValidityPeriod(
            DateTime newBeginningTime, DateTime newExpirationTime, LockModificationWay modificationWay)
        {
            modificationWay.IsExist();

            return PostRequest("changePeriod",
                CreateDictionary(
                    "lockId", FingerprintToOperate.LockId.ToString(),
                    "fingerprintId", FingerprintToOperate.Id.ToString(),
                    "startDate", newBeginningTime.GetUnixTimeInMilliseconds().ToString(),
                    "endDate", newExpirationTime.GetUnixTimeInMilliseconds().ToString(),
                    "changeType", modificationWay.ToString("d")
                )
            );
        }

        public Task DeleteFingerprint(LockModificationWay modificationWay)
        {
            modificationWay.IsExist();

            return PostRequest("delete",
                CreateDictionary(
                    "lockId", FingerprintToOperate.LockId.ToString(),
                    "fingerprintId", FingerprintToOperate.Id.ToString(),
                    "deleteType", modificationWay.ToString("d")
                )
            );
        }

        public Task DeleteAllTheLockFingerprints(int lockId)
        {
            return PostRequest("clear",
                CreateDictionary(
                    "lockId", lockId.ToString()
                )
            );
        }
    }
}
