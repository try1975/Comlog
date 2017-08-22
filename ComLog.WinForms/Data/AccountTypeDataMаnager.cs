using ComLog.Common;
using ComLog.Dto;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class AccountTypeDataM�nager : TypedDataM�nager<AccountTypeDto, int>, IAccountTypeDataM�nager
    {
        public AccountTypeDataM�nager() : base(ComLogConstants.ClientAppApi.AccountTypes)
        {
        }
    }
}