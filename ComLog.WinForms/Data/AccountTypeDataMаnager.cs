using ComLog.Common;
using ComLog.Dto;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class AccountTypeDataMànager : TypedDataMànager<AccountTypeDto, int>, IAccountTypeDataMànager
    {
        public AccountTypeDataMànager() : base(ComLogConstants.ClientAppApi.AccountTypes)
        {
        }
    }
}