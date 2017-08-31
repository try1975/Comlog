using System;
using System.Web.Http;
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

        public decimal Get(string currencyId, DateTime date)
        {
            return currencyId.Equals("USD", StringComparison.OrdinalIgnoreCase) ? 1m : _api.GetRate(currencyId, date);
        }
    }
}