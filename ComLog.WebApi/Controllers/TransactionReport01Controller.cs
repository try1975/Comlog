using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WebApi.Formaters;
using ComLog.WebApi.Maintenance;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    [RoutePrefix("api/transactions")]
    public class TransactionReport01Controller : ApiController
    {
        private ITransactionApi _api;

        public TransactionReport01Controller(ITransactionApi api)
        {
            _api = api;
        }

        [HttpGet]
        [Route("report01")]
        public virtual IEnumerable<TransactionReport01Dto> GetReport01()
        {
            return _api.GetReportItems();
        }

        [HttpGet]
        [Route("report02")]
        public HttpResponseMessage GetReport02()
        {
            var result = _api.GetReportItems();
            return new HttpResponseMessage()
            {
                Content = new ObjectContent<IEnumerable<TransactionReport01Dto>>(result, new TransactionReport01CsvFormatter())
            };
        }
    }
}
