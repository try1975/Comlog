using System;
using System.Collections.Generic;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Controllers
{
    public class TransactionsController : TypedController<TransactionDto, int>
    {
        public TransactionsController(ITransactionApi api) : base(api)
        {
        }

        public IEnumerable<TransactionExtDto> Get(DateTime dateFrom, DateTime dateTo)
        {
            return ((ITransactionApi)_api).GetItemsByPeriod(dateFrom, dateTo);
        }
    }
}