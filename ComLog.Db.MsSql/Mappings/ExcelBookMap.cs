using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.Mappings
{
    internal class ExcelBookMap : EntityTypeConfiguration<ExcelBookEntity>
    {
        public ExcelBookMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable($"{tableName}");

            Property(e => e.Dt)
                .HasColumnType("date")
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_ExcelBookDt", 1) { IsUnique = false }))
                ;

            Property(e => e.BankName)
                .HasMaxLength(250)
                ;
            Property(e => e.AccountName)
                .HasMaxLength(250)
                ;
            Property(e => e.AccountTypeName)
                .HasMaxLength(250)
                ;

            Property(e => e.CurrencyId)
                .HasMaxLength(250)
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

            Property(e => e.TrType)
                .HasMaxLength(250)
                ;

            Property(e => e.Splus)
                .HasColumnType("money")
                ;

            Property(e => e.Sminus)
                .HasColumnType("money")
                ;

            Property(e => e.Ssum)
                .HasColumnType("money")
                ;

            HasOptional(s => s.Bank)
               .WithMany(l => l.ExcelBooks)
               .HasForeignKey(s => s.BankId)
               .WillCascadeOnDelete(false)
               ;

            HasOptional(s => s.Account)
               .WithMany(l => l.ExcelBooks)
               .HasForeignKey(s => s.AccountId)
               .WillCascadeOnDelete(false)
               ;

            HasOptional(s => s.AccountType)
               .WithMany(l => l.ExcelBooks)
               .HasForeignKey(s => s.AccountTypeId)
               .WillCascadeOnDelete(false)
               ;

            HasOptional(s => s.TransactionType)
               .WithMany(l => l.ExcelBooks)
               .HasForeignKey(s => s.TransactionTypeId)
               .WillCascadeOnDelete(false)
               ;

        }
    }
}