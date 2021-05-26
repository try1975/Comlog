using System;
using System.Web.Http;
using CurEx.WebApi.Helpers;
using CurEx.WebApi.Maintenance.Interfaces;

namespace CurEx.WebApi.Controllers
{
    public class CurrencyRateController : ApiController
    {
        private readonly ICurrencyRateApi _api;

        public CurrencyRateController(ICurrencyRateApi api)
        {
            _api = api;
        }

        public decimal Get(string currencyId, /*[DateTimeParameter(DateFormat = "dd_MM_yyyy")]*/ DateTime date, string currencyTo = "USD")
        {
            currencyId = currencyId.ToUpper().Trim();
            currencyTo = currencyTo.ToUpper().Trim();
            if (currencyId == currencyTo) return 1m;
            return _api.GetRate(currencyFrom: currencyId, currencyTo, date);
        }
    }
}