using System.Collections.Generic;
using ComLog.Dto;

namespace ComLog.WebApi.Maintenance
{
    public interface ITransactionApi : ITypedApi<TransactionDto, int>
    {
        IEnumerable<TransactionReport01Dto> GetReportItems();
    }
}