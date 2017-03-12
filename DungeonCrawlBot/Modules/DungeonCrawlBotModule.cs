using DungeonCrawlApi.DungeonCrawlApiFactory;
using DungeonCrawlApi.DungeonCrawlWebSocketApi;
using Ninject.Modules;

namespace DungeonCrawlBot.Modules
{
    public class DungeonCrawlBotModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDungeonCrawlApiFactory>()
                .To<DungeonCrawlWebSocketApiFactory>();
        }
    }
}