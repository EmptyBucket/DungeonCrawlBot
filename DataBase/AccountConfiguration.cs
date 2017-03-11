using System.Data.Entity.ModelConfiguration;

namespace DataBase
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            HasKey(account => account.Id);
            Property(account => account.Email)
                .IsRequired()
                .HasMaxLength(200);
            Property(account => account.Name)
                .IsRequired()
                .HasMaxLength(200);
            Property(account => account.Password)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}