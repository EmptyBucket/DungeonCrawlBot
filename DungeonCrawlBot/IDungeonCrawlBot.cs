using System.Threading.Tasks;

namespace DungeonCrawlBot
{
    public interface IDungeonCrawlBot
    {
        Task ConnectAsync(string socketServer);
        void Dispose();
        Task LoginAsync(string username, string password);
        Task RegisterAsync(string username, string password, string email);
        Task SendMessageAsync(string message);
        Task WatchAsync(string username);
    }
}