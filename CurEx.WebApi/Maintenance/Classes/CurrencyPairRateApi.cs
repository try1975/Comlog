using System;
using System.Collections.Generic;
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

        public IEnumerable<CurrencyPairRateDto> GetLast10(string currencyPairId)
        {
            var entities =
                Query.GetEntities().Where(z => z.CurrencyPairId == currencyPairId).OrderByDescending(z=>z.RateDate).Take(10).ToList();
            return Mapper.Map<List<CurrencyPairRateDto>>(entities);
        }
    }
}