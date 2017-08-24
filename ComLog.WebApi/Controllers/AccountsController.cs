using System.Collections.Generic;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    public class AccountsController : TypedController<AccountDto,int>
    {
        public AccountsController(IAccountApi api) : base(api)
        {
        }

        public IEnumerable<AccountExtDto> Get(bool ext)
        {
            return ((IAccountApi)_api).GetExtItems();
        }
    }
}