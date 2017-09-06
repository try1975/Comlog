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

        public decimal Get(string currencyId, /*[DateTimeParameter(DateFormat = "dd_MM_yyyy")]*/ DateTime date)
        {
            return currencyId.Equals("USD", StringComparison.OrdinalIgnoreCase) ? 1m : _api.GetRate(currencyId, date);
        }
    }
}