using ComLog.Common;
using ComLog.Dto;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class CurrencyDataMànager : TypedDataMànager<CurrencyDto, string>, ICurrencyDataMànager
    {
        public CurrencyDataMànager() : base(ComLogConstants.ClientAppApi.Currencies)
        {
        }
    }
}