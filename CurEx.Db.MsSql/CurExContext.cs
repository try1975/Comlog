using System.Data.Entity;
using CurEx.Db.Entities.Entities;
using CurEx.Db.MsSql.Mappings;
using CurEx.Db.MsSql.Migrations;

namespace CurEx.Db.MsSql
{
    [DbConfigurationType(typeof(ConfigContext))]
    public class CurExContext : DbContext
    {
        public CurExContext() : base("name=CurEx")
        {
        }
        public CurExContext(string conn= "CurEx") : base($"name={conn}")
        {
        }

        public virtual DbSet<CurrencyPairEntity> CurrencyPairs { get; set; }
        public virtual DbSet<CurrencyPairRateEntity> CurrencyPairRates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            const string prefix = "";
            modelBuilder.Configurations.Add(new CurrencyPairMap($"{prefix}{nameof(CurrencyPairs)}"));
            modelBuilder.Configurations.Add(new CurrencyPairRateMap($"{prefix}{nameof(CurrencyPairRates)}"));
        }
    }

    public class ConfigContext : DbConfiguration
    {
        public ConfigContext()
        {
            SetDatabaseInitializer(new CreateDatabaseIfNotExists<CurExContext>());
            SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<CurExContext, Configuration>());
        }
    }
}