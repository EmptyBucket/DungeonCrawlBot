using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BehindTheNameGenerator.NameGenerator;
using DataBase;
using DungeonCrawlApi.DungeonCrawlApiFactory;
using DungeonCrawlApi.Generators;

namespace DungeonCrawlBot
{
    public class DungeonCrawlRegistrarAccountBot
    {
        private readonly WebServerLabel _serverLabel;
        private readonly IDungeonCrawlApiFactory _dungeonCrawlApiFactory;
        private readonly INameGenerator _nameGenerator;
        private readonly IPasswordGenerator _passwordGenerator;
        private readonly IEmailDomainGenerator _emailDomainGenerator;
        private readonly string[] _proxyAddresses;

        public DungeonCrawlRegistrarAccountBot(WebServerLabel serverLabel,
            IDungeonCrawlApiFactory dungeonCrawlApiFactory, INameGenerator nameGenerator,
            IPasswordGenerator passwordGenerator, IEmailDomainGenerator emailDomainGenerator,
            string[] proxyAddresses)
        {
            _serverLabel = serverLabel;
            _dungeonCrawlApiFactory = dungeonCrawlApiFactory;
            _nameGenerator = nameGenerator;
            _passwordGenerator = passwordGenerator;
            _emailDomainGenerator = emailDomainGenerator;
            _proxyAddresses = proxyAddresses;
        }

        public async Task RegisterAccount(int count)
        {
            using (var dbContext = new DbContext())
            {
                var accountService = new AccountDataService(dbContext);
                for (var i = 0; i < count; i++)
                {
                    using (var dungeonCrawlApi = _dungeonCrawlApiFactory.Factory())
                    {
                        dungeonCrawlApi.Proxy = new WebProxy(_proxyAddresses[i]);

                        var name = await _nameGenerator.GenerateAsync();
                        var emailDomain = _emailDomainGenerator.Next().First();
                        var password = _passwordGenerator.Next().First();
                        var email = $"{name}@{emailDomain}";

                        await dungeonCrawlApi.ConnectAsync(_serverLabel.Url);
                        await dungeonCrawlApi.RegisterAsync(name, password, email);

                        accountService.Add(new DataBase.Account
                        {
                            Email = email,
                            Name = name,
                            Password = password
                        });
                    }
                }
            }
        }
    }
}