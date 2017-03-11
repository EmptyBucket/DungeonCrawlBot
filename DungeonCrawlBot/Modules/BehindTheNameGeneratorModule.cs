using System.Net;
using System.Net.Http;
using BehindTheNameGenerator;
using Ninject.Modules;

namespace DungeonCrawlBot.Modules
{
    public class BehindTheNameGeneratorModule : NinjectModule
    {
        private readonly string _proxyAddress;

        public BehindTheNameGeneratorModule(string proxyAddress)
        {
            _proxyAddress = proxyAddress;
        }

        public override void Load()
        {
            var httpClientHandler = new HttpClientHandler {Proxy = new WebProxy(_proxyAddress)};
            var httpClient = new HttpClient(httpClientHandler);
            Bind<IClient>()
                .To<HttpClientAdapter>()
                .WithConstructorArgument(httpClient);
            Bind<IParametersFactory>()
                .To<BehindTheNameParametersFactory>()
                .OnActivation(factory => factory.SelectAll());
            Bind<IUrlBuilder>()
                .To<BehindTheNameUrlBuilder>();
            Bind<INameGenerator>()
                .To<BehindTheNameGenerator.BehindTheNameGenerator>();
            Bind<IParser>()
                .To<BehindTheNameParser>();
        }
    }
}