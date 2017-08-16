using ComLog.Dto;
using ComLog.Maintenance;

namespace ComLog.Controllers
{
    public class BanksController : TypedController<BankDto,int>
    {
        //[HttpGet]
        //public IEnumerable<BankDto> GetBanks()
        //{
        //    var bankApi = new BankApi(new BankQuery(new WorkContext()));
        //    return bankApi.GetItems();
        //}
        public BanksController(IBankApi api) : base(api)
        {
        }
    }
}