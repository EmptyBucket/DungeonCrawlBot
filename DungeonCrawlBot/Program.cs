using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DungeonCrawlApi.Modules;
using DungeonCrawlBot.Modules;
using Knapcode.TorSharp;
using Ninject;

namespace DungeonCrawlBot
{
    public class Program
    {
        public static List<string> ProxyList = new List<string>();

        public static async Task DeployTorClients(int count)
        {
            var taskWaitingConfigurationEnd = new List<Task>();
            for (var i = 0; i < count; i++)
            {
                var offset = i * 3;
                var extractedToolsDirectory = Path.Combine(Path.GetTempPath(), "Tor", "TorExtracted" + i);
                var settings = new TorSharpSettings
                {
                    ZippedToolsDirectory = Path.Combine(Path.GetTempPath(), "Tor", "TorZipped"),
                    ExtractedToolsDirectory = extractedToolsDirectory,
                    PrivoxyPort = 1337 + offset,
                    TorSocksPort = 1338 + offset,
                    TorControlPort = 1339 + offset,
                    TorControlPassword = "foobar" + i,
                    TorDataDirectory = Path.Combine(extractedToolsDirectory, "DataDirectory")
                };
                var torSharpProxy = new TorSharpProxy(settings);
                await torSharpProxy.ConfigureAndStartAsync();
                ProxyList.Add($"http://localhost:{settings.PrivoxyPort}");
                taskWaitingConfigurationEnd.Add(torSharpProxy.WaitForConnectionAsync());
            }
            Task.WaitAll(taskWaitingConfigurationEnd.ToArray());
        }

        public static async Task RegisterAccounts(int count)
        {
            var registrarKernelConfiguration = new KernelConfiguration(
                new BehindTheNameGeneratorModule(),
                new DungeonCrawlRegistrarAccountBotModule(DungeonCrawlServerLabels.Akrasiac, ProxyList),
                new PasswordGeneratorModule(),
                new EmailGeneratorModule());
            var registrarReadonlyKernel = registrarKernelConfiguration.BuildReadonlyKernel();
            var dungeonCrawlRegistrarAccountBot = registrarReadonlyKernel.Get<DungeonCrawlRegistrarAccountBot>();
            await dungeonCrawlRegistrarAccountBot.RegisterAccount(count);
        }

        public static async Task GoToUser(string userName, int count)
        {
            var botKernelConfiguration = new KernelConfiguration(
                new DungeonCrawlBotModule(DungeonCrawlServerLabels.Akrasiac, ProxyList));
            var botReadonlyKernel = botKernelConfiguration.BuildReadonlyKernel();
            using (var dungeonCrawlBot = botReadonlyKernel.Get<DungeonCrawlBot>())
            {
                await dungeonCrawlBot.Connect(count);
                await dungeonCrawlBot.Login();
                await dungeonCrawlBot.WatchUser(userName);
            }
        }

        public static void Main(string[] args)
        {
            const int count = 2;
            DeployTorClients(count).Wait();
            GoToUser("BackslashEcho", 2).Wait();
        }
    }
}