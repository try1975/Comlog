using ComLog.Db.Entities;
using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Maintenance.Classes
{
    public class AccountApi : TypedApi<AccountDto, AccountEntity, int>, IAccountApi
    {
        public AccountApi(IAccountQuery query) : base(query)
        {
        }
    }
}