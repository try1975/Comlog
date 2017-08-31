using System;
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
              new CurrencyPairEntity { Id = "USDCHF" },
              new CurrencyPairEntity { Id = "HKDUSD" },
              new CurrencyPairEntity { Id = "RUBUSD" },
              new CurrencyPairEntity { Id = "UAHUSD" }
            );

            context.CurrencyPairRates.AddOrUpdate(
                p => new { p.RateDate, p.CurrencyPairId },
                new CurrencyPairRateEntity() { RateDate = new DateTime(2016,1,1), CurrencyPairId = "EURUSD", Rate = 1.1m},
                new CurrencyPairRateEntity() { RateDate = new DateTime(2016, 1, 1), CurrencyPairId = "GBPUSD", Rate = 1.55m },
                new CurrencyPairRateEntity() { RateDate = new DateTime(2016, 1, 1), CurrencyPairId = "USDCHF", Rate = 0.9523m },
                new CurrencyPairRateEntity() { RateDate = new DateTime(2016, 1, 1), CurrencyPairId = "HKDUSD", Rate = 0.12m },
                new CurrencyPairRateEntity() { RateDate = new DateTime(2016, 1, 1), CurrencyPairId = "RUBUSD", Rate = 0.0172m },
                new CurrencyPairRateEntity() { RateDate = new DateTime(2016, 1, 1), CurrencyPairId = "UAHUSD", Rate = 0.0393m }
            );

        }
    }
}
