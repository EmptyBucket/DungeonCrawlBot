using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BehindTheNameGenerator.Client
{
    //adapter pattern
    public class HttpClientAdapter : IClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetResultAsync(Uri url)
        {
            var resultAsync = await _httpClient.GetStringAsync(url).ConfigureAwait(false);
            return resultAsync;
        }
    }
}