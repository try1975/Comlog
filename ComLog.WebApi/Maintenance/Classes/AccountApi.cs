using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using ComLog.Db.Entities;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WebApi.Maintenance.Interfaces;

namespace ComLog.WebApi.Maintenance.Classes
{
    public class AccountApi : TypedApi<AccountDto, AccountEntity, int>, IAccountApi
    {
        public AccountApi(IAccountQuery query) : base(query)
        {
        }

        public IEnumerable<AccountExtDto> GetExtItems()
        {
            var list = Query.GetEntities()
                 .Include(nameof(AccountEntity.Bank))
                 .Include(nameof(AccountEntity.AccountType))
                 ;
            return Mapper.Map<List<AccountExtDto>>(list);
        }
    }
}