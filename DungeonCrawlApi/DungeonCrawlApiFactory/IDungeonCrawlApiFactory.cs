using DungeonCrawlApi.DungeonCrawlWebSocketApi;

namespace DungeonCrawlApi.DungeonCrawlApiFactory
{
    public interface IDungeonCrawlApiFactory
    {
        IDungeonCrawlApi Factory();
    }
}