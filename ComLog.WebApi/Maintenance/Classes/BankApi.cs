using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ComLog.Db.Entities;
using ComLog.Dto;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Maintenance.Classes
{
    public class BankApi : TypedApi<BankDto, BankEntity, int>, IBankApi
    {
        public BankApi(IBankQuery query) : base(query)
        {
        }

        public override IEnumerable<BankDto> GetItems()
        {
            return Mapper.Map<List<BankDto>>(Query.GetEntities().OrderBy(z=>z.Name));
        }
    }
}