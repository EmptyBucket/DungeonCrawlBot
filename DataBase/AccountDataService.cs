using System.Linq;

namespace DataBase
{
    public class AccountDataService
    {
        private readonly DbContext _context;

        public AccountDataService(DbContext context)
        {
            _context = context;
        }

        public IQueryable<Account> GetAccounts() => _context.Accounts;

        public void Add(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void Clear()
        {
            _context.Database.ExecuteSqlCommand("truncate table Accounts");
            _context.SaveChanges();
        }
    }
}