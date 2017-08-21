using CurEx.Db.Entities.Entities;

namespace CurEx.Db.MsSql.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CurExContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CurExContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.CurrencyPairs.AddOrUpdate(
              p => p.Id,
              new CurrencyPairEntity() { Id = "EURUSD" },
              new CurrencyPairEntity { Id = "GBPUSD" },
              new CurrencyPairEntity { Id = "USDCHF" }
            );

        }
    }
}
