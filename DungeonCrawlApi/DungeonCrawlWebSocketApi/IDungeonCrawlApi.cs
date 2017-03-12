using System;
using System.Net;
using System.Threading.Tasks;

namespace DungeonCrawlApi.DungeonCrawlWebSocketApi
{
    public interface IDungeonCrawlApi : IDisposable
    {
        Task ConnectAsync(string socketServer);
        new void Dispose();
        Task LoginAsync(string username, string password);
        Task RegisterAsync(string username, string password, string email);
        Task SendMessageAsync(string message);
        Task WatchAsync(string username);
        IWebProxy Proxy { get; set; }
    }
}