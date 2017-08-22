using System.Collections.Generic;
using System.Web.Http;
using ComLog.Dto;
using ComLog.WebApi.Maintenance;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    [RoutePrefix("api/transactions/report01")]
    public class TransactionReport01Controller : ApiController
    {
        private ITransactionApi _api;

        public TransactionReport01Controller(ITransactionApi api)
        {
            _api = api;
        }

        public virtual IEnumerable<TransactionReport01Dto> Get()
        {
            return _api.GetReportItems();
        }
    }
}
