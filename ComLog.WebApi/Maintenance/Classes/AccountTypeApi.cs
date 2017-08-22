using ComLog.Db.Entities;
using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Maintenance.Classes
{
    public class AccountTypeApi : TypedApi<AccountTypeDto, AccountTypeEntity, int>, IAccountTypeApi
    {
        public AccountTypeApi(IAccountTypeQuery query) : base(query)
        {
        }
    }
}