using System;

namespace CurEx.WebApi.Maintenance.Interfaces
{
    public interface ICurrencyRateApi
    {
        decimal GetRate(string currencyId, DateTime date);
    }
}