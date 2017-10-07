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
    public class AccountApi : TypedApi<AccountDto, AccountEntity, int>, IAccountApi
    {
        private readonly ITransactionQuery _transactionQuery;

        public AccountApi(IAccountQuery query, ITransactionQuery transactionQuery) : base(query)
        {
            _transactionQuery = transactionQuery;
        }

        public IEnumerable<AccountExtDto> GetExtItems(bool withBalance)
        {
            var accounts = Query.GetEntities()
                 .Include(nameof(AccountEntity.Bank))
                 .Include(nameof(AccountEntity.AccountType))
                 .OrderBy(z => z.Bank.Name)
                 .ThenBy(z => z.Name)
                 .ThenBy(z => z.CurrencyId)
                 .ToList()
                 ;
            if (!withBalance)
            {
                return Mapper.Map<List<AccountExtDto>>(accounts);
            }
            var maxDate = DateTime.Today.AddDays(1);
            var dbBalances = _transactionQuery.GetEntities()
                    .Where(z => z.TransactionDate < maxDate)
                    .GroupBy(x => new { x.AccountId })
                    .Select(y => new
                    {
                        Id = y.Key.AccountId,
                        DbBalance = y.Sum(c => c.Dcc)
                    })
                    .ToList()
                    ;
            var list = accounts
                .GroupJoin(dbBalances, x => x.Id, y => y.Id, (o, i) => new { acc = o, bal = i })
                .SelectMany(xy => xy.bal.DefaultIfEmpty(), (x, y) => new { account = x.acc, balance = y })
                .Select(o => new AccountExtDto
                {
                    Id = o.account.Id,
                    Name = o.account.Name,
                    AccountNumber = o.account.AccountNumber,
                    BankId = o.account.BankId,
                    CurrencyId = o.account.CurrencyId,
                    AccountTypeId = o.account.AccountTypeId,
                    Closed = o.account.Closed,
                    ChangeBy = o.account.ChangeBy,
                    ChangeAt = o.account.ChangeAt,
                    BankName = o.account.Bank.Name,
                    AccountTypeName = o.account.AccountType.Name,
                    DbBalance = o.balance == null ? 0 : o.balance.DbBalance
                })
                .ToList();
            return list;
        }
    }
}