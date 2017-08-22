using ComLog.Common;
using ComLog.Dto;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class CurrencyDataM�nager : TypedDataM�nager<CurrencyDto, string>, ICurrencyDataM�nager
    {
        public CurrencyDataM�nager() : base(ComLogConstants.ClientAppApi.Currencies)
        {
        }
    }
}