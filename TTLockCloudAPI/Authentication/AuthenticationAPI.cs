using System;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class AuthenticationAPI : TTLockCloudAPI, IAuthenticationAPI
    {
        public AuthenticationAPI(Uri serverUri = null)
            : base("oauth2/", serverUri)
        { }

        private static AuthenticationInfo __GetAuthInfo(AuthInfoDto dto)
        {
            return ConvertDto(() => new AuthenticationInfo(
                dto.access_token,
                dto.expires_in,
                dto.refresh_token,
                dto.scope.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            ));
        }

        public async Task<User> Authenticate(string username, string md5UserPassword)
        {
            VerifyUsername(username);
            var password = PrepareMD5Password(md5UserPassword);

            var userDto = await PostRequest<UserDto>(
                "token",
                CreateDictionary(
                    "client_id", ApplicationID,
                    "grant_type", "password",
                    "client_secret", ApplicationSecret,
                    "username", username,
                    "password", password
                ),
                TTLockData.None
            ).ConfigureAwait(false);

            return new User(userDto.uid, __GetAuthInfo(userDto));
        }

        public async Task<AuthenticationInfo> RefreshAuthentication(string refreshToken)
        {
            refreshToken.IsNotNullOrEmpty(nameof(refreshToken));

            var authInfoDto = await PostRequest<UserDto>(
                "token",
                CreateDictionary(
                    "client_id", ApplicationID,
                    "client_secret", ApplicationSecret,
                    "refresh_token", refreshToken
                ),
                TTLockData.None
            ).ConfigureAwait(false);

            return __GetAuthInfo(authInfoDto);
        }
    }
}
