using System.Collections.Generic;
using DungeonCrawlApi.DungeonCrawlApiFactory;
using DungeonCrawlBot.Account;
using Ninject.Modules;
using System.Linq;

namespace DungeonCrawlBot.Modules
{
    public class DungeonCrawlBotModule : NinjectModule
    {
        private readonly IEnumerable<string> _proxyAddresses;
        private readonly WebServerLabel _serverLabel;

        public DungeonCrawlBotModule(WebServerLabel serverLabel, IEnumerable<string> proxyAddresses)
        {
            _proxyAddresses = proxyAddresses;
            _serverLabel = serverLabel;
        }

        public override void Load()
        {
            Bind<DungeonCrawlBot>()
                .ToSelf()
                .WithConstructorArgument("serverLabel", _serverLabel)
                .WithConstructorArgument("proxyAddresses", _proxyAddresses.ToArray());
            Bind<IAccountProvider>().To<AccountDataServiceAdapter>();
            Bind<IDungeonCrawlApiFactory>().To<DungeonCrawlWebSocketApiFactory>();
        }
    }
}