using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DataBase;

namespace DungeonCrawlBot.Account
{
    public class AccountDataServiceAdapter : IAccountProvider
    {
        private readonly AccountDataService _accountDataService;

        public AccountDataServiceAdapter(AccountDataService accountDataService)
        {
            _accountDataService = accountDataService;
        }

        static AccountDataServiceAdapter() =>
            Mapper.Initialize(expression => expression.CreateMap<DataBase.Account, Account>());

        public Task<List<Account>> GetAccounts() => _accountDataService.GetAccounts().ProjectToListAsync<Account>();
    }
}