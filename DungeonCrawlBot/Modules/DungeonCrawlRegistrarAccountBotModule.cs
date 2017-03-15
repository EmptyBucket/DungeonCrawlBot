using System.Collections.Generic;
using DungeonCrawlApi.DungeonCrawlApiFactory;
using Ninject.Modules;
using System.Linq;

namespace DungeonCrawlBot.Modules
{
    public class DungeonCrawlRegistrarAccountBotModule : NinjectModule
    {
        private readonly WebServerLabel _serverLabel;
        private readonly IEnumerable<string> _proxyAddresses;

        public DungeonCrawlRegistrarAccountBotModule(WebServerLabel serverLabel, IEnumerable<string> proxyAddresses)
        {
            _serverLabel = serverLabel;
            _proxyAddresses = proxyAddresses;
        }

        public override void Load()
        {
            Bind<DungeonCrawlRegistrarAccountBot>()
                .ToSelf()
                .WithConstructorArgument("serverLabel", _serverLabel)
                .WithConstructorArgument("proxyAddresses", _proxyAddresses.ToArray());
            Bind<IDungeonCrawlApiFactory>().To<DungeonCrawlWebSocketApiFactory>();
        }
    }
}