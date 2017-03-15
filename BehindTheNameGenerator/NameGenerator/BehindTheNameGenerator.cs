using System;
using System.Threading.Tasks;
using BehindTheNameGenerator.Client;
using BehindTheNameGenerator.Parser;
using BehindTheNameGenerator.UrlBuilder;

namespace BehindTheNameGenerator.NameGenerator
{
    public class BehindTheNameGenerator : INameGenerator
    {
        private readonly IUrlBuilder _urlBuilder;
        private readonly IClientFactory _clientFactory;
        private readonly IParser _parser;

        public BehindTheNameGenerator(IUrlBuilder urlBuilder, IClientFactory clientFactory, IParser parser)
        {
            _urlBuilder = urlBuilder;
            _clientFactory = clientFactory;
            _parser = parser;
        }

        public async Task<string> GenerateAsync()
        {
            var url = _urlBuilder.Build();
            var uri = new Uri(url);
            var result = await _clientFactory.Factory().GetResultAsync(uri).ConfigureAwait(false);
            var name = _parser.Parse(result);
            return name;
        }
    }
}