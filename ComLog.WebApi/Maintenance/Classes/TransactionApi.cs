using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using ComLog.Db.Entities;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Maintenance.Classes
{
    public class TransactionApi : TypedApi<TransactionDto, TransactionEntity, int>, ITransactionApi
    {
        public TransactionApi(ITransactionQuery query) : base(query)
        {
        }

        public IEnumerable<TransactionReport01Dto> GetReportItems()
        {
            var list = Query.GetEntities()
                //.Where(z=>z.Dt>=new DateTime(2017,1,1))
                .Include(nameof(TransactionEntity.Bank))
                .Include(nameof(TransactionEntity.Account))
                .Include(nameof(TransactionEntity.TransactionType))
                ;
            return Mapper.Map<List<TransactionReport01Dto>>(list);
        }

        public IEnumerable<TransactionExtDto> GetItemsByPeriod(DateTime dateFrom, DateTime dateTo)
        {
            dateTo = dateTo.AddDays(1);
            var list = Query.GetEntities()
                .Where(z => z.Dt >= dateFrom && z.Dt < dateTo)
                .Include(nameof(TransactionEntity.Bank))
                .Include(nameof(TransactionEntity.Account))
                .Include(nameof(TransactionEntity.TransactionType))
                .OrderByDescending(z => z.TransactionDate)
                .ThenByDescending(z=>z.ChangeAt)
                ;
            return Mapper.Map<List<TransactionExtDto>>(list);
        }

        public override IEnumerable<TransactionDto> GetItems()
        {
            return Mapper.Map<List<TransactionDto>>(Query.GetEntities().Take(10));
        }
    }
}