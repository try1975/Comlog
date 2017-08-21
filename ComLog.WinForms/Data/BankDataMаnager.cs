using ComLog.Common;
using ComLog.Dto;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class BankDataMànager : TypedDataMànager<BankDto, int>, IBankDataMànager
    {
        public BankDataMànager() : base(ComLogConstants.ClientAppApi.Banks)
        {
        }
    }
}