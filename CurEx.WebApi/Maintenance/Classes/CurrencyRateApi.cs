using System;
using System.Linq;
using CurEx.Db.Entities.QueryProcessors;
using CurEx.WebApi.Maintenance.Interfaces;

namespace CurEx.WebApi.Maintenance.Classes
{
    public class CurrencyRateApi : ICurrencyRateApi
    {
        private readonly ICurrencyPairRateQuery _query;

        public CurrencyRateApi(ICurrencyPairRateQuery query)
        {
            _query = query;
        }

        public decimal GetRate(string currencyId, DateTime date)
        {
            currencyId = currencyId.ToUpper().Trim();
            var currencyPairRateEntity = _query.GetEntities().Where(z => z.CurrencyPairId.Contains(currencyId) && z.RateDate <= date).OrderByDescending(z => z.RateDate).FirstOrDefault();
            if (currencyPairRateEntity == null) return 1m;
            if (currencyPairRateEntity.CurrencyPairId.StartsWith(currencyId)) return currencyPairRateEntity.Rate;
            if (currencyPairRateEntity.CurrencyPairId.EndsWith(currencyId)) return 1 / currencyPairRateEntity.Rate;
            return 1m;
        }

        public decimal GetRatePair(string currencyFrom, string currencyTo, DateTime date)
        {
            currencyFrom = currencyFrom.ToUpper().Trim();
            currencyTo = currencyTo.ToUpper().Trim();
            var currencyPairRateEntity = _query.GetEntities()
                .Where(z => z.CurrencyPairId.Contains(currencyFrom) && z.CurrencyPairId.Contains(currencyTo) && z.RateDate <= date)
                .OrderByDescending(z => z.RateDate)
                .FirstOrDefault();
            if (currencyPairRateEntity == null) return 1m;
            if (currencyPairRateEntity.CurrencyPairId.StartsWith(currencyFrom)) return currencyPairRateEntity.Rate;
            if (currencyPairRateEntity.CurrencyPairId.EndsWith(currencyFrom)) return 1 / currencyPairRateEntity.Rate;
            return 1m;
        }
    }
}