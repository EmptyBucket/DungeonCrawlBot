using DungeonCrawlApi.DungeonCrawlWebSocketApi;

namespace DungeonCrawlApi.DungeonCrawlApiFactory
{
    //abstract factory pattern
    public interface IDungeonCrawlApiFactory
    {
        IDungeonCrawlApi Factory();
    }
}