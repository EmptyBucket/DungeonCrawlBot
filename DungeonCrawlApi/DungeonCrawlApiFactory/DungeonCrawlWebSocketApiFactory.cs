using DungeonCrawlApi.DungeonCrawlWebSocketApi;

namespace DungeonCrawlApi.DungeonCrawlApiFactory
{
    //abstract factory pattern
    public class DungeonCrawlWebSocketApiFactory : IDungeonCrawlApiFactory
    {
        public IDungeonCrawlApi Factory() => new DungeonCrawlWebSocketApi.DungeonCrawlWebSocketApi();
    }
}