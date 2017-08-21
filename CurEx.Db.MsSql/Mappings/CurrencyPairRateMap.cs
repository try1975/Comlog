using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using CurEx.Db.Entities.Entities;

namespace CurEx.Db.MsSql.Mappings
{
    public class CurrencyPairRateMap : EntityTypeConfiguration<CurrencyPairRateEntity>
    {
        public CurrencyPairRateMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable($"{tableName}");

            Property(e => e.RateDate)
                .HasColumnType("date")
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_CurRate", 1) { IsUnique = true }))
                ;

            Property(e => e.CurrencyPairId)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_CurRate", 2) { IsUnique = true }))
                ;

            Property(e => e.Rate)
                .HasColumnType("money")
            ;

            Property(e => e.OpenRate)
                .HasColumnType("money")
                ;

            Property(e => e.CloseRate)
                .HasColumnType("money")
                ;

            Property(e => e.LowRate)
                .HasColumnType("money")
                ;

            Property(e => e.HighRate)
                .HasColumnType("money")
                ;

            HasRequired(s => s.CurrencyPair)
               .WithMany(l => l.CurrencyPairRates)
               .HasForeignKey(s => s.CurrencyPairId)
               .WillCascadeOnDelete(false)
               ;
        }
    }
}