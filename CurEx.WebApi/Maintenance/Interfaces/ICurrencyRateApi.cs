using System;

namespace CurEx.WebApi.Maintenance.Interfaces
{
    public interface ICurrencyRateApi
    {
        decimal GetRate(string currencyFrom, string currencyTo, DateTime date);
    }
}