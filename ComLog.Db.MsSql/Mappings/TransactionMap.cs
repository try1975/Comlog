using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.Mappings
{
    public class TransactionMap : EntityTypeConfiguration<TransactionEntity>
    {
        public TransactionMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable($"{tableName}");

            Property(e => e.Dt)
                .HasColumnType("date")
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_TransactionDt", 1) { IsUnique = false }))
                ;

            Property(e => e.Credits)
                .HasColumnType("money")
            ;

            Property(e => e.Debits)
                .HasColumnType("money")
                ;

            Property(e => e.Charges)
                .HasColumnType("money")
                ;

            Property(e => e.FromTo)
                .HasMaxLength(500)
                ;

            Property(e => e.Description)
                .HasMaxLength(500)
                ;

            Property(e => e.Report)
                .HasMaxLength(250)
                ;

            Property(e => e.UsdCredits)
                .HasColumnType("money")
            ;

            Property(e => e.UsdDebits)
                .HasColumnType("money")
                ;

            Property(e => e.Dcc)
                .HasColumnType("money")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
            ;

            Property(e => e.UsdDcc)
                .HasColumnType("money")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                ;

            Property(e => e.ChangeBy)
                .HasMaxLength(50)
                ;
            Property(e => e.ChangeAt)
                .IsOptional()
                ;

            HasRequired(s => s.Bank)
               .WithMany(l => l.Transactions)
               .HasForeignKey(s => s.BankId)
               .WillCascadeOnDelete(false)
               ;

            HasRequired(s => s.Account)
               .WithMany(l => l.Transactions)
               .HasForeignKey(s => s.AccountId)
               .WillCascadeOnDelete(false)
               ;

            HasRequired(s => s.Currency)
               .WithMany(l => l.Transactions)
               .HasForeignKey(s => s.CurrencyId)
               .WillCascadeOnDelete(false)
               ;

            HasOptional(s => s.TransactionType)
               .WithMany(l => l.Transactions)
               .HasForeignKey(s => s.TransactionTypeId)
               .WillCascadeOnDelete(false)
               ;
        }
    }
}