using System;
using System.Collections.Generic;
using System.Web.Http;
using ComLog.Dto.Ext;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountMsDailyController : ApiController
    {
        private IAccountApi _accountApi;

        public AccountMsDailyController(IAccountApi accountApi)
        {
            _accountApi = accountApi;
        }

        [HttpGet]
        [Route("report01")]
        public virtual IEnumerable<AccountMsDailyDto> GetReport01(DateTime? dateFrom=null, DateTime? dateTo=null)
        {
            return _accountApi.GetMsDaily(dateFrom, dateTo);
        }
    }
}
