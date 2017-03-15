using System;
using System.Net;
using System.Net.Http;

namespace BehindTheNameGenerator.Client
{
    //abstract factory pattern
    public class ProxyHttpClientFactory : IClientFactory
    {
        private readonly Uri _proxyAddress;

        public ProxyHttpClientFactory(Uri proxyAddress)
        {
            _proxyAddress = proxyAddress;
        }

        public IClient Factory()
        {
            var httpMessageHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(_proxyAddress)
            };
            var httpClient = new HttpClient(httpMessageHandler);
            var httpClientAdapter = new HttpClientAdapter(httpClient);
            return httpClientAdapter;
        }
    }
}