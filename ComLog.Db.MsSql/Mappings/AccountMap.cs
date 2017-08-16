using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.Mappings
{
    public class AccountMap : EntityTypeConfiguration<AccountEntity>
    {
        public AccountMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable($"{tableName}");

            Property(e => e.Name)
                .HasMaxLength(250)
                .IsRequired()
                ;

            HasRequired(s => s.Bank)
               .WithMany(l => l.Accounts)
               .HasForeignKey(s => s.BankId)
               .WillCascadeOnDelete(false)
               ;
            HasRequired(s => s.AccountType)
               .WithMany(l => l.Accounts)
               .HasForeignKey(s => s.AccountTypeId)
               .WillCascadeOnDelete(false)
               ;
            HasRequired(s => s.Currency)
               .WithMany(l => l.Accounts)
               .HasForeignKey(s => s.CurrencyId)
               .WillCascadeOnDelete(false)
               ;
        }
    }
}