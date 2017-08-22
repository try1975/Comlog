using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    public class CurrenciesController : TypedController<CurrencyDto, string>
    {
        public CurrenciesController(ICurrencyApi api) : base(api)
        {
        }
    }
}