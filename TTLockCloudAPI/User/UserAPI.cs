using System;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class UserAPI : TTLockCloudAPI, IUserAPI
    {
        public UserAPI(Uri serverUri = null)
            : base("v3/user/", serverUri)
        { }

        public Task Delete(string username)
        {
            VerifyUsername(username);

            return PostRequest("delete",
                CreateDictionary(
                    "username", username
                ),
                TTLockData.AppId | TTLockData.AppSecret | TTLockData.CurDate
            );
        }

        public async Task<PageResult<UserRegistrationInfo>> GetAllUsers(DateTime? startDate, DateTime? finishDate, int page = 1, int pageSize = 20)
        {
            var dto = await PostRequest<PageResultDto<UserRegistrationInfoDto>>("list",
                CreateDictionary(
                    "startDate", (startDate?.GetUnixTimeInMilliseconds() ?? 0).ToString(),
                    "endDate", (finishDate?.GetUnixTimeInMilliseconds() ?? 0).ToString()
                ),
                TTLockData.AppId | TTLockData.AppSecret | TTLockData.CurDate
            ).ConfigureAwait(false);

            return ConvertDto(
                () => dto.ToPageResult(
                        uri => new UserRegistrationInfo(
                            uri.userid,
                            uri.regtime.GetDateTimeFromUnixMilliseconds()
                        )
                )
            );
        }

        public async Task<UserRegistrationResult> Register(string username, string md5Password)
        {
            VerifyUsername(username);
            var password = PrepareMD5Password(md5Password);

            var dto = await PostRequest<UserRegistrationResultDto>("register",
                CreateDictionary(
                    "username", username,
                    "password", password
                ),
                TTLockData.AppId | TTLockData.AppSecret | TTLockData.CurDate
            ).ConfigureAwait(false);

            return ConvertDto(() => new UserRegistrationResult(dto.username));
        }

        public Task ResetPassword(string username, string md5Password)
        {
            VerifyUsername(username);
            var password = PrepareMD5Password(md5Password);

            return PostRequest("resetPassword",
                CreateDictionary(
                    "username", username,
                    "password", password
                ),
                TTLockData.AppId | TTLockData.AppSecret | TTLockData.CurDate
            );
        }
    }
}
