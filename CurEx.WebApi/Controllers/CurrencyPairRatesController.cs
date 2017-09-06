using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using CurEx.Dto.Dto;
using CurEx.WebApi.Formatters;
using CurEx.WebApi.Maintenance.Interfaces;

namespace CurEx.WebApi.Controllers
{
    //[RoutePrefix("api/test")]
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

        [HttpGet]
        //[Route("last10", Name = nameof(GetLast10) + "Route")]
        public HttpResponseMessage GetLast10(string currencyPairId)
        {
            var result = ((ICurrencyPairRateApi)_api).GetLast10(currencyPairId);
            return new HttpResponseMessage()
            {
                Content = new ObjectContent<IEnumerable<CurrencyPairRateDto>>(result, new CurrencyPairCsvFormatter())
            };
        }
    }
}