using System;
using System.Collections.Generic;
using CurEx.Dto.Dto;

namespace CurEx.WebApi.Maintenance.Interfaces
{
    public interface ICurrencyPairRateApi : ITypedApi<CurrencyPairRateDto, int>
    {
        CurrencyPairRateDto GetByDate(string currencyPairId, DateTime rateDate);
        IEnumerable<CurrencyPairRateDto> GetLastN(string currencyPairId, int lastN);
    }
}