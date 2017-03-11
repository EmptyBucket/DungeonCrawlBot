namespace DataBase
{
    public class AccountService
    {
        private readonly DbContext _context;

        public AccountService(DbContext context)
        {
            _context = context;
        }

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