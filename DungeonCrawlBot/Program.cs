using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BehindTheNameGenerator;
using DataBase;
using DungeonCrawlBot.Modules;
using Knapcode.TorSharp;
using Ninject;
using Ninject.Modules;
using System.Net.WebSockets;

namespace DungeonCrawlBot
{
    public class Program
    {
        public static readonly string[] WebSocketServers = {
            "wss://crawl.project357.org/socket",
            "ws://crawl.akrasiac.org:8080/socket",
            "ws://crawl.berotato.org:8080/socket",
            "ws://crawl.xtahua.com:8080/socket"
        };

        public static async Task Start()
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

//            await new TorSharpToolFetcher(settings, new HttpClient()).FetchAsync();

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
                    for (var i = 0; i < 10; i++)
                    {
                        using (var dungeonCrawlBotSocket = new DungeonCrawlWebBotSocket())
                        {
                            dungeonCrawlBotSocket.Proxy = new WebProxy(proxyAddress);

                            var name = await nameGenerator.GenerateAsync();
                            var emailDomain = emailDomainGenerator.Next().First();
                            var password = passwordGenerator.Next().First();
                            var email = $"{name}@{emailDomain}";

                            await dungeonCrawlBotSocket.ConnectAsync(WebSocketServers[1]);
                            await dungeonCrawlBotSocket.RegisterAsync(name, password, email);

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

        public static void Main(string[] args)
        {
            Start().Wait();
        }
    }
}