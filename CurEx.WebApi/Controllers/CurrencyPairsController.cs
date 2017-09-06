using CurEx.Dto.Dto;
using CurEx.WebApi.Maintenance.Interfaces;

namespace CurEx.WebApi.Controllers
{
    public class CurrencyPairsController : TypedController<CurrencyPairDto, string>
    {
        public CurrencyPairsController(ICurrencyPairApi api) : base(api)
        {
        }
    }
}