using System;
using System.Linq;
using AutoMapper;
using CurEx.Db.Entities.Entities;
using CurEx.Db.Entities.QueryProcessors;
using CurEx.Dto.Dto;
using CurEx.WebApi.Maintenance.Interfaces;

namespace CurEx.WebApi.Maintenance.Classes
{
    public class CurrencyPairRateApi : TypedApi<CurrencyPairRateDto, CurrencyPairRateEntity, int>, ICurrencyPairRateApi
    {
        public CurrencyPairRateApi(ICurrencyPairRateQuery query) : base(query)
        {
        }

        public CurrencyPairRateDto GetByDate(string currencyPairId, DateTime rateDate)
        {
            var entity =
                Query.GetEntities().FirstOrDefault(z => z.CurrencyPairId == currencyPairId && z.RateDate == rateDate);
            return Mapper.Map<CurrencyPairRateDto>(entity);
        }
    }
}