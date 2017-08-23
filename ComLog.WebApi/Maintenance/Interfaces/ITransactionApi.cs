using System;
using System.Collections.Generic;
using ComLog.Dto;
using ComLog.Dto.Ext;

namespace ComLog.WebApi.Maintenance.Interfaces
{
    public interface ITransactionApi : ITypedApi<TransactionDto, int>
    {
        IEnumerable<TransactionReport01Dto> GetReportItems();
        IEnumerable<TransactionExtDto> GetItemsByPeriod(DateTime dateFrom, DateTime dateTo);
    }
}