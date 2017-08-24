using System;
using System.Web.Http;

namespace CurEx.WebApi.Controllers
{
    public class CurrencyRateController : ApiController
    {
        public decimal Get(string currencyId, DateTime date)
        {
            if (currencyId == "USD") return 1m;
            if (currencyId == "EUR") return 1.1m;
            if (currencyId == "GBP") return 1.5m;
            return 1;
        }
    }
}