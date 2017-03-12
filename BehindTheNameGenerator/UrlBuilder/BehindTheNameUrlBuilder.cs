namespace BehindTheNameGenerator
{
    public class BehindTheNameUrlBuilder : IUrlBuilder
    {
        private readonly IParametersFactory _parametersFactory;
        private const string BaseUrl = "https://www.behindthename.com/random/random.php";

        public BehindTheNameUrlBuilder(IParametersFactory parametersFactory)
        {
            _parametersFactory = parametersFactory;
        }

        public string Build()
        {
            var parameters = _parametersFactory.Factory();
            var url = $"{BaseUrl}?{parameters}";
            return url;
        }
    }
}