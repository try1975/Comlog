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
              new CurrencyEntity { Id = "USD", Ord = 1},
              new CurrencyEntity { Id = "EUR", Ord = 2 },
              new CurrencyEntity { Id = "GBP", Ord = 3 },
              new CurrencyEntity { Id = "CHF", Ord = 4 },
              new CurrencyEntity { Id = "HKD", Ord = 5 },
              new CurrencyEntity { Id = "RUB", Ord = 6 },
              new CurrencyEntity { Id = "UAH", Ord = 7 }
            );
        }
    }
}
