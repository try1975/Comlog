using ComLog.Common;
using ComLog.Dto;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class BankDataM�nager : TypedDataM�nager<BankDto, int>, IBankDataM�nager
    {
        public BankDataM�nager() : base(ComLogConstants.ClientAppApi.Banks)
        {
        }
    }
}