using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    public class TransactionsController : TypedController<TransactionDto, int>
    {
        public TransactionsController(ITransactionApi api) : base(api)
        {
        }
    }
}