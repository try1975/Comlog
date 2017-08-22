using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    public class AccountTypesController : TypedController<AccountTypeDto,int>
    {
        public AccountTypesController(IAccountTypeApi api) : base(api)
        {
        }
    }
}