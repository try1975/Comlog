using System.Data.Entity.ModelConfiguration;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.Mappings
{
    public class CurrencyMap : EntityTypeConfiguration<CurrencyEntity>
    {
        public CurrencyMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasMaxLength(10)
                ;

            ToTable($"{tableName}");

            Property(e => e.ChangeBy)
                .HasMaxLength(50)
                ;
            Property(e => e.ChangeAt)
                .IsOptional()
                ;
        }
    }
}