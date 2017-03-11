using System;
using System.Threading.Tasks;

namespace BehindTheNameGenerator
{
    public class BehindTheNameGenerator : INameGenerator
    {
        private readonly IUrlBuilder _urlBuilder;
        private readonly IClient _client;
        private readonly IParser _parser;

        public BehindTheNameGenerator(IUrlBuilder urlBuilder, IClient client, IParser parser)
        {
            _urlBuilder = urlBuilder;
            _client = client;
            _parser = parser;
        }

        public async Task<string> GenerateAsync()
        {
            var url = _urlBuilder.Build();
            var uri = new Uri(url);
            var result = await _client.GetResultAsync(uri);
            var name = _parser.Parse(result);
            return name;
        }
    }
}