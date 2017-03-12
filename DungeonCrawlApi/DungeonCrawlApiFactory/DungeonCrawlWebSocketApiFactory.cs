using DungeonCrawlApi.DungeonCrawlWebSocketApi;

namespace DungeonCrawlApi.DungeonCrawlApiFactory
{
    public class DungeonCrawlWebSocketApiFactory : IDungeonCrawlApiFactory
    {
        public IDungeonCrawlApi Factory() => new DungeonCrawlWebSocketApi.DungeonCrawlWebSocketApi();
    }
}