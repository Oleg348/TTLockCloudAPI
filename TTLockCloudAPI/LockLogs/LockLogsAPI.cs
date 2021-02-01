using System;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public class LockLogsAPI : TTLockCloudAPI, ILockLogsAPI
    {
        public LockLogsAPI(Uri serverUri = null)
            : base("v3/lockRecord/", serverUri)
        { }

        public async Task<PageResult<LockOpening>> GetLockOpenings(
            int lockId, DateTime? from = null, DateTime? until = null,
            int page = 1, int pageSize = 20
        )
        {
            var requestData = CreateDictionary(
                "lockId", lockId.ToString(),
                "pageNo", page.ToString(),
                "pageSize", pageSize.ToString()
            );
            if (from != null)
                requestData.Add("startDate", from.Value.GetUnixTimeInMilliseconds().ToString());
            if (until != null)
                requestData.Add("endDate", until.Value.GetUnixTimeInMilliseconds().ToString());

            var dto = await PostRequest<PageResultDto<LockOpeningDto>>(
                "list", requestData
            ).ConfigureAwait(false);

            return ConvertDto(
                () => dto.ToPageResult(
                    o => new LockOpening(
                        o.lockId,
                        o.success == 1,
                        o.username,
                        (OpeningEntityType)o.recordType,
                        o.keyboardPwd,
                        o.lockDate.GetDateTimeFromUnixMilliseconds(),
                        o.serverDate.GetDateTimeFromUnixMilliseconds()
                    )
                )
            );
        }

        public Task UploadLockOpenings(int lockId, string openings)
        {
            openings.IsNotNullOrEmpty(nameof(openings));

            return PostRequest("upload",
                CreateDictionary(
                    "lockId", lockId.ToString(),
                    "records", openings
                )
            );
        }
    }
}
