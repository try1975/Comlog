using ComLog.Common;
using ComLog.Dto;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class AccountDataManager : TypedDataMаnager<AccountDto, int>, IAccountDataManager
    {
        public AccountDataManager() : base(ComLogConstants.ClientAppApi.Accounts)
        {
        }
    }
}