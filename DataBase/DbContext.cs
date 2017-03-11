using System.Data.Entity;

namespace DataBase
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("DbContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}