using System.Collections.Generic;
using System.Web.Http;
using ComLog.Dto.Ext;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    [RoutePrefix("api/checkbalance")]
    public class CheckBalanceController : ApiController
    {
        private IAccountApi _api;

        public CheckBalanceController(IAccountApi api)
        {
            _api = api;
        }

        [HttpGet]
        //[Route("report01")]
        public virtual IEnumerable<CheckBalanceDto> Get()
        {
            return _api.GetCheckBalanceItems();
        }
    }
}
