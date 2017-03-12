using DungeonCrawlApi.DungeonCrawlWebSocketApi;

namespace DungeonCrawlApi.DungeonCrawlApiFactory
{
    public class DungeonCrawlBrowserEmulatorApiFactory : IDungeonCrawlApiFactory
    {
        public IDungeonCrawlApi Factory()
        {
            return new DungeonCrawlBrowserEmulatorApi.DungeonCrawlBrowserEmulatorApi();
        }
    }
}