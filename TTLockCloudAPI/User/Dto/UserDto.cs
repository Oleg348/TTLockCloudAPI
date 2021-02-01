namespace OrbitaTech.TTLock
{
    internal class AuthInfoDto
    {
        public string access_token { get; set; }

        public int expires_in { get; set; }

        public string scope { get; set; }

        public string refresh_token { get; set; }
    }

    internal class UserDto : AuthInfoDto
    {
        public int uid { get; set; }
    }
}
