using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    internal static class TTLockHttpRequestsHelper
    {
        private static readonly HttpClient __client = new HttpClient();

        /// <summary>
        /// Perform post request to TTLock server.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="dataDictionary"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="HttpRequestException"/>
        public static async Task<string> Post(Uri requestUri, IDictionary<string, string> dataDictionary)
        {
            requestUri.IsNotNull(nameof(requestUri));
            var data = new FormUrlEncodedContent(dataDictionary);

            var response = await __client.PostAsync(requestUri, data).ConfigureAwait(false);
            return await response.EnsureSuccessStatusCode()
                .Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
