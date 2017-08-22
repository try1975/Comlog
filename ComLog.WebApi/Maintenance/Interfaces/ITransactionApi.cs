using System.Collections.Generic;
using ComLog.Dto;

namespace ComLog.WebApi.Maintenance.Interfaces
{
    public interface ITransactionApi : ITypedApi<TransactionDto, int>
    {
        IEnumerable<TransactionReport01Dto> GetReportItems();
    }
}