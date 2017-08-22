using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    public class BanksController : TypedController<BankDto,int>
    {
        public BanksController(IBankApi api) : base(api)
        {
        }
    }
}