using ComLog.Db.Entities;
using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Maintenance.Classes
{
    public class TransactionTypeApi : TypedApi<TransactionTypeDto, TransactionTypeEntity, int>, ITransactionTypeApi
    {
        public TransactionTypeApi(ITransactionTypeQuery query) : base(query)
        {
        }
    }
}