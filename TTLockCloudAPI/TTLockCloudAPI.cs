using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    using static TTLockHttpRequestsHelper;

    public interface ITTLockCloudAPI
    {
        /// <summary>
        /// API server URI.
        /// </summary>
        Uri ServerURI { get; }

        /// <summary>
        /// URI of API.
        /// </summary>
        Uri ApiURI { get; }

        /// <summary>
        /// User to work with.
        /// </summary>
        /// <exception cref="InvalidOperationException">Wasn't set.</exception>
        /// <exception cref="ArgumentNullException"/>
        User UserToOperate { get; set; }
    }

    /// <summary>
    /// Any API method will throw <see cref="InvalidOperationException"/>
    /// if <see cref="ApplicationID"/> or <see cref="ApplicationSecret"/>
    /// wasn't initialized.
    /// </summary>
    public abstract class TTLockCloudAPI : ITTLockCloudAPI
    {
        #region Private fields

        private static string __applicationId;
        private static string __applicationSecret;

        private User _user;

        #endregion Private fields

        #region Public static fields

        /// <summary>
        /// Default TTLock server path.
        /// </summary>
        public const string DefaultServerURIPath = "https://api.ttlock.com/";

        /// <summary>
        /// Default TTLock server URI.
        /// </summary>
        public static readonly Uri DefaultServerURI = new Uri(DefaultServerURIPath);

        #endregion Public static fields

        #region Public static properties

        /// <summary>
        /// TTLock registered application Id.
        /// </summary>
        /// <exception cref="InvalidOperationException">Getter will throw if it wasn't set</exception>
        /// <exception cref="ArgumentNullException">New value is null</exception>
        /// <exception cref="ArgumentException">New value is empty</exception>
        public static string ApplicationID
        {
            protected get => __applicationId ?? throw Error.InvalidOperation("Application ID wasn't initialized.");
            set
            {
                value.IsNotNull(nameof(value));
                value.IsValid(s => !string.IsNullOrEmpty(s), nameof(value), "Application ID can't be empty");

                __applicationId = value;
            }
        }

        /// <summary>
        /// TTLock registered application secret key.
        /// </summary>
        /// <exception cref="InvalidOperationException">Getter will throw if it wasn't set</exception>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException">New value is empty</exception>
        public static string ApplicationSecret
        {
            protected get => __applicationSecret ?? throw Error.InvalidOperation("Application secret wasn't initialized.");
            set
            {
                value.IsNotNull(nameof(value));
                value.IsValid(s => !string.IsNullOrEmpty(s), nameof(value), "Application secret can't be empty");

                __applicationSecret = value;
            }
        }

        #endregion Public static properties

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="apiPath"></param>
        /// <param name="serverUri"></param>
        /// <exception cref="FormatException"><paramref name="apiPath"/> is invalid.</exception>
        protected TTLockCloudAPI(string apiPath, Uri serverUri = null)
        {
            ServerURI = serverUri ?? DefaultServerURI;

            ApiURI = new Uri(ServerURI, apiPath);
        }

        protected static long GetCurrentUnixTimeInMilliseconds => DateTime.UtcNow.GetUnixTimeInMilliseconds();

        #region Public properties

        public Uri ServerURI { get; }

        public Uri ApiURI { get; }

        public User UserToOperate
        {
            get => _user ?? throw Error.InvalidOperation("Working user wasn't initialized");
            set => _user = value.IsNotNull(nameof(value));
        }

        #endregion Public properties

        #region Private methods

        private static bool __HasFlag(TTLockData value, TTLockData flag)
        {
            return (value & flag) != 0;
        }

        private static TTLockAPIException GetException(RequestResultDto dto)
        {
            return GetException(dto.errcode, dto.errmsg, dto.description);
        }

        private static void __VerifyResult(RequestResultDto dto)
        {
            if (dto.errcode != 0)
                throw GetException(dto);
        }
        private static void __VerifyAnswer(string answer)
        {
            var requestResult = answer.ParseJson<RequestResultDto>();
            __VerifyResult(requestResult);
        }

        private async Task<string> __PostRequestBase(string apiRequestPath, IDictionary<string, string> dataDictionary, TTLockData ttLockData)
        {
            apiRequestPath
                .IsNotNull(nameof(apiRequestPath))
                .IsValid(p => !string.IsNullOrEmpty(p), nameof(apiRequestPath), "Request path can't be null or empty");

            if (ttLockData != TTLockData.None)
            {
                if (__HasFlag(ttLockData, TTLockData.AppId))
                    dataDictionary.Add("clientId", ApplicationID);
                if (__HasFlag(ttLockData, TTLockData.AppSecret))
                    dataDictionary.Add("clientSecret", ApplicationSecret);
                if (__HasFlag(ttLockData, TTLockData.UserAccessToken))
                    dataDictionary.Add("accessToken", UserToOperate.AccessToken);
                if (__HasFlag(ttLockData, TTLockData.CurDate))
                    dataDictionary.Add("date", GetCurrentUnixTimeInMilliseconds.ToString());
            }

            var requestUri = new Uri(ApiURI, apiRequestPath);
            var jsonAnswer = await Post(requestUri, dataDictionary).ConfigureAwait(false);

            __VerifyAnswer(jsonAnswer);
            return jsonAnswer;
        }

        private static TTLockAPIException GetUnknownServerAnswerException(Exception e)
        {
            return new TTLockAPIException("Некорректный ответа сервера", e);
        }

        #endregion Private methods

        #region Protected methods

        protected static TTLockAPIException GetException(int errorCode, string message, string description = null)
        {
            var ex = new TTLockAPIException(errorCode, message);
            if (description != null)
                ex.Data.Add("Description", description);
            return ex;
        }

        protected static IDictionary<string, string> CreateDictionary(params string[] keysAndValues)
        {
            keysAndValues
                .IsValid(kv => kv.Length % 2 == 0, nameof(keysAndValues), "Key and values array must contain even length");

            var dataDictionary = new Dictionary<string, string>();
            for (int i = 0; i < keysAndValues.Length; i += 2)
            {
                dataDictionary.Add(keysAndValues[i], keysAndValues[i + 1]);
            }
            return dataDictionary;
        }

        /// <summary>
        /// Perform post request to TTLock server.
        /// </summary>
        /// <typeparam name="T">Server answer dto class.</typeparam>
        /// <param name="apiRequestPath"></param>
        /// <returns>Request result dto.</returns>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        protected async Task<T> PostRequest<T>(string apiRequestPath, IDictionary<string, string> data, TTLockData ttLockData = TTLockData.Default)
            where T : class, new()
        {
            var jsonAnswer = await __PostRequestBase(apiRequestPath, data, ttLockData).ConfigureAwait(false);

            try
            {
                return jsonAnswer.ParseJson<T>();
            }
            catch (Exception e)
            {
                throw GetUnknownServerAnswerException(e);
            }
        }

        /// <summary>
        /// Perform post request to TTLock server.
        /// </summary>
        /// <param name="apiRequestPath"></param>
        /// <param name="keysAndValues"></param>
        /// <returns>Request result dto.</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        protected Task PostRequest(string apiRequestPath, IDictionary<string, string> data, TTLockData ttLockData = TTLockData.Default)
        {
            return __PostRequestBase(apiRequestPath, data, ttLockData);
        }

        /// <summary>
        /// Perform conversion from dto to model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="convert"></param>
        /// <remarks>It catches any exception during conversion.</remarks>
        /// <returns><paramref name="convert"/> result.</returns>
        /// <exception cref="TTLockAPIException">There was exceptions during conversion.</exception>
        protected static T ConvertDto<T>(Func<T> convert)
        {
            try
            {
                return convert();
            }
            catch (Exception e)
            {
                throw GetUnknownServerAnswerException(e);
            }
        }

        #endregion Protected methods

        [Flags]
        protected enum TTLockData
        {
            None = 0,
            AppId = 1,
            AppSecret = 2,
            UserAccessToken = 4,
            CurDate = 8,
            Default = AppId | UserAccessToken | CurDate
        }
    }
}
