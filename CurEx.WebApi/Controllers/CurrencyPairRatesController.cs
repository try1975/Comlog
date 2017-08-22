using System;
using System.Web.Mvc;
using CurEx.Dto.Dto;
using CurEx.WebApi.Maintenance.Interfaces;

namespace CurEx.WebApi.Controllers
{
    public class CurrencyPairRatesController : TypedController<CurrencyPairRateDto, int>
    {
        //[HttpGet]
        //public IEnumerable<BankDto> GetBanks()
        //{
        //    var bankApi = new BankApi(new BankQuery(new WorkContext()));
        //    return bankApi.GetItems();
        //}
        public CurrencyPairRatesController(ICurrencyPairRateApi api) : base(api)
        {
        }

        [HttpGet]
        public CurrencyPairRateDto GetByDate(string currencyPairId, DateTime rateDate)
        {
            return ((ICurrencyPairRateApi)_api).GetByDate(currencyPairId, rateDate);
        }
    }
}