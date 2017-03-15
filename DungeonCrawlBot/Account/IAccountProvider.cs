using System.Collections.Generic;
using System.Threading.Tasks;

namespace DungeonCrawlBot.Account
{
    public interface IAccountProvider
    {
        Task<List<Account>> GetAccounts();
    }
}