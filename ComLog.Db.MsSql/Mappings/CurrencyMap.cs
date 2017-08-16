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
        }
    }
}