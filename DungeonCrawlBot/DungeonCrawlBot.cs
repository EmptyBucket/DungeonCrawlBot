using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DungeonCrawlApi.DungeonCrawlApiFactory;
using DungeonCrawlApi.DungeonCrawlWebSocketApi;
using DungeonCrawlBot.Account;

namespace DungeonCrawlBot
{
    public class DungeonCrawlBot : IDisposable
    {
        private readonly IDungeonCrawlApiFactory _dungeonCrawlApiFactory;
        private readonly WebServerLabel _serverLabel;
        private readonly string[] _proxyAddresses;
        private readonly IAccountProvider _accountProvider;
        private readonly List<IDungeonCrawlApi> _apiList = new List<IDungeonCrawlApi>();
        private int _userCount;
        private bool _connected;

        public DungeonCrawlBot(WebServerLabel serverLabel, IDungeonCrawlApiFactory dungeonCrawlApiFactory,
            IAccountProvider accountProvider, string[] proxyAddresses)
        {
            _dungeonCrawlApiFactory = dungeonCrawlApiFactory;
            _serverLabel = serverLabel;
            _proxyAddresses = proxyAddresses;
            _accountProvider = accountProvider;
        }

        public async Task Connect(int count)
        {
            if(_connected)
                throw new Exception("Бот уже подключен");
            _connected = true;
            _userCount = count;
            for (var i = 0; i < count; i++)
            {
                var dungeonCrawlApi = _dungeonCrawlApiFactory.Factory();
                dungeonCrawlApi.Proxy = new WebProxy(_proxyAddresses[i]);
                _apiList.Add(dungeonCrawlApi);
                await dungeonCrawlApi.ConnectAsync(_serverLabel.Url);
            }
        }

        public async Task Login()
        {
            var accounts = await _accountProvider.GetAccounts();
            // ReSharper disable once PossibleMultipleEnumeration
            if (accounts.Count < _userCount)
                throw new Exception("Число зарегистрированных пользователей меньше, чем подключенных");
            // ReSharper disable once PossibleMultipleEnumeration
            using (var accountsEnumeratory = accounts.GetEnumerator())
                foreach (var api in _apiList)
                {
                    accountsEnumeratory.MoveNext();
                    var account = accountsEnumeratory.Current;
                    await api.LoginAsync(account.Name, account.Password);
                }
        }

        public async Task GoLobby()
        {
            foreach (var api in _apiList)
                await api.GoLobby();
        }

        public async Task WatchUser(string userName)
        {
            foreach (var api in _apiList)
                await api.WatchAsync(userName);
        }

        public void Dispose()
        {
            foreach (var dungeonCrawlWebBotSocket in _apiList)
                dungeonCrawlWebBotSocket.Dispose();
        }
    }
}