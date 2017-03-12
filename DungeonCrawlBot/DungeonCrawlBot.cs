using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BehindTheNameGenerator;
using DataBase;
using DungeonCrawlApi.DungeonCrawlApiFactory;
using DungeonCrawlApi.DungeonCrawlWebSocketApi;
using DungeonCrawlApi.Generators;
using DungeonCrawlApi.Modules;
using Knapcode.TorSharp;
using Ninject;
using Ninject.Modules;

namespace DungeonCrawlBot
{
    public class DungeonCrawlBot
    {
        private readonly IDungeonCrawlApiFactory _dungeonCrawlApiFactory;

        public DungeonCrawlBot(IDungeonCrawlApiFactory dungeonCrawlApiFactory)
        {
            _dungeonCrawlApiFactory = dungeonCrawlApiFactory;
        }

        public static readonly string[] WebSocketServers = {
            "wss://crawl.project357.org/socket",
            "ws://crawl.akrasiac.org:8080/socket",
            "ws://crawl.berotato.org:8080/socket",
            "ws://crawl.xtahua.com:8080/socket"
        };

        public async Task RegisterAccount(int count)
        {
            var settings = new TorSharpSettings
            {
                ZippedToolsDirectory = Path.Combine(Path.GetTempPath(), "TorZipped"),
                ExtractedToolsDirectory = Path.Combine(Path.GetTempPath(), "TorExtracted"),
                PrivoxyPort = 1337,
                TorSocksPort = 1338,
                TorControlPort = 1339,
                TorControlPassword = "foobar"
            };

            await new TorSharpToolFetcher(settings, new HttpClient()).FetchAsync();

            var proxyAddress = $"http://localhost:{settings.PrivoxyPort}";

            var behindTheNameGeneratorModule = new INinjectModule[] {
                new BehindTheNameGeneratorModule(proxyAddress),
                new EmailGeneratorModule(),
                new PasswordGeneratorModule()
            };

            var kernelConfiguration = new KernelConfiguration(behindTheNameGeneratorModule);
            var readonlyKernel = kernelConfiguration.BuildReadonlyKernel();

            using (var torSharpProxy = new TorSharpProxy(settings))
            {
                await torSharpProxy.ConfigureAndStartAsync();
                await Task.Delay(5000);

                var nameGenerator = readonlyKernel.Get<INameGenerator>();
                var emailDomainGenerator = readonlyKernel.Get<IEmailDomainGenerator>();
                var passwordGenerator = readonlyKernel.Get<IPasswordGenerator>();

                using (var dbContext = new DbContext())
                {
                    var accountService = new AccountService(dbContext);
                    for (var i = 0; i < 56; i++)
                    {
                        using (var dungeonCrawlApi = _dungeonCrawlApiFactory.Factory())
                        {
                            dungeonCrawlApi.Proxy = new WebProxy(proxyAddress);

                            var name = await nameGenerator.GenerateAsync();
                            var emailDomain = emailDomainGenerator.Next().First();
                            var password = passwordGenerator.Next().First();
                            var email = $"{name}@{emailDomain}";

                            await dungeonCrawlApi.ConnectAsync(WebSocketServers[1]);
                            await dungeonCrawlApi.RegisterAsync(name, password, email);

                            accountService.Add(new Account
                            {
                                Email = email,
                                Name = name,
                                Password = password
                            });
                        }
                        await torSharpProxy.GetNewIdentityAsync();
                    }
                }

                torSharpProxy.Stop();
            }
        }

        public async Task LoginToRoom(string name, int count)
        {
            var proxyList = new List<TorSharpProxy>();
            var botLit = new List<IDungeonCrawlApi>();

            var accountService = new AccountService(new DbContext());
            var accounts = accountService.GetAccounts().ToArray();
            for (var i = 0; i < count; i++)
            {
                var settings = new TorSharpSettings
                {
                    ZippedToolsDirectory = Path.Combine(Path.GetTempPath(), "TorZipped" + i),
                    ExtractedToolsDirectory = Path.Combine(Path.GetTempPath(), "TorExtracted" + i),
                    PrivoxyPort = 1337 + i * 3,
                    TorSocksPort = 1338 + i * 3,
                    TorControlPort = 1339 + i * 3,
                    TorControlPassword = "foobar" + i
                };

                var proxyAddress = $"http://localhost:{settings.PrivoxyPort}";

                var torSharpProxy = new TorSharpProxy(settings);
                await torSharpProxy.ConfigureAndStartAsync();
                await Task.Delay(5000);
                var dungeonCrawlApi = _dungeonCrawlApiFactory.Factory();
                dungeonCrawlApi.Proxy = new WebProxy(proxyAddress);
                proxyList.Add(torSharpProxy);
                botLit.Add(dungeonCrawlApi);

                await dungeonCrawlApi.ConnectAsync(WebSocketServers[1]);
                await dungeonCrawlApi.LoginAsync(accounts[i].Name, accounts[i].Password);
                await dungeonCrawlApi.WatchAsync(name);
            }

            foreach (var torSharpProxy in proxyList)
                torSharpProxy.Stop();
            foreach (var dungeonCrawlWebBotSocket in botLit)
                dungeonCrawlWebBotSocket.Dispose();
        }
    }
}