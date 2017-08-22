using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    public class AccountsController : TypedController<AccountDto,int>
    {
        public AccountsController(IAccountApi api) : base(api)
        {
        }
    }
}