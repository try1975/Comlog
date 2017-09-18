using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WorkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WorkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Currencies.AddOrUpdate(
              p => p.Id,
              new CurrencyEntity() { Id = "USD" },
              new CurrencyEntity() { Id = "EUR" },
              new CurrencyEntity { Id = "GBP" },
              new CurrencyEntity { Id = "CHF" },
              new CurrencyEntity { Id = "HKD" },
              new CurrencyEntity { Id = "RUB" },
              new CurrencyEntity { Id = "UAH" }
            );
        }
    }
}
