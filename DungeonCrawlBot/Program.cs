using DungeonCrawlApi.DungeonCrawlApiFactory;
using DungeonCrawlBot.Modules;
using Ninject;

namespace DungeonCrawlBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dungeonCrawlBotModule = new DungeonCrawlBotModule();
            var kernelConfiguration = new KernelConfiguration(dungeonCrawlBotModule);
            var readonlyKernel = kernelConfiguration.BuildReadonlyKernel();
            var dungeonCrawlApiFactory = readonlyKernel.Get<IDungeonCrawlApiFactory>();
            var dungeonCrawlBot = new DungeonCrawlBot(dungeonCrawlApiFactory);
        }
    }
}