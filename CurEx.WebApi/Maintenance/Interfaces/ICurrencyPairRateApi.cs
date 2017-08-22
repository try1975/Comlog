using System;
using CurEx.Dto.Dto;

namespace CurEx.WebApi.Maintenance.Interfaces
{
    public interface ICurrencyPairRateApi : ITypedApi<CurrencyPairRateDto, int>
    {
        CurrencyPairRateDto GetByDate(string currencyPairId, DateTime rateDate);
    }
}