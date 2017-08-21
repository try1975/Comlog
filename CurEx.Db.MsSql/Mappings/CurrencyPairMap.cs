using System.Data.Entity.ModelConfiguration;
using CurEx.Db.Entities.Entities;

namespace CurEx.Db.MsSql.Mappings
{
    public class CurrencyPairMap : EntityTypeConfiguration<CurrencyPairEntity>
    {
        public CurrencyPairMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasMaxLength(10)
                ;

            ToTable($"{tableName}");
        }
    }
}