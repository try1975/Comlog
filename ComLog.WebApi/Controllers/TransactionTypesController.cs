using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    public class TransactionTypesController : TypedController<TransactionTypeDto,int>
    {
        public TransactionTypesController(ITransactionTypeApi api) : base(api)
        {
        }
    }
}