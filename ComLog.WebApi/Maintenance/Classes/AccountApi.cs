using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
        private IAccountTypeQuery _accountTypeQuery;

        public AccountApi(IAccountQuery query, ITransactionQuery transactionQuery, IAccountTypeQuery accountTypeQuery) : base(query)
        {
            _transactionQuery = transactionQuery;
            _accountTypeQuery = accountTypeQuery;
        }

        public IEnumerable<AccountExtDto> GetExtItems()
        {
            //var list = Query.GetEntities()
            //     .Include(nameof(AccountEntity.Bank))
            //     .Include(nameof(AccountEntity.AccountType))
            //     .OrderBy(z => z.Bank.Name)
            //     .ThenBy(z => z.Name)
            //     ;
            //return Mapper.Map<List<AccountExtDto>>(list);
            var list = _transactionQuery.GetEntities()
                .Include(nameof(TransactionEntity.Bank))
                .Include(nameof(TransactionEntity.Account))
                //.Include(nameof(AccountEntity.AccountType))
                .GroupBy(x => new { x.BankId, x.AccountId, x.CurrencyId })
                .Select(y => new AccountExtDto
                {
                    Id = y.FirstOrDefault().AccountId,
                    Name = y.FirstOrDefault().Account.Name,
                    AccountNumber = y.FirstOrDefault().Account.AccountNumber,
                    BankId = y.FirstOrDefault().Account.BankId,
                    CurrencyId = y.Key.CurrencyId,
                    AccountTypeId = y.FirstOrDefault().Account.AccountTypeId,
                    Closed = y.FirstOrDefault().Account.Closed,
                    ChangeBy = y.FirstOrDefault().Account.ChangeBy,
                    ChangeAt = y.FirstOrDefault().Account.ChangeAt,
                    BankName = y.FirstOrDefault().Bank.Name,
                    //AccountTypeName= y.FirstOrDefault().Account.AccountType.Name,
                    DbBalance = y.Sum(c => c.Dcc)
                }
                ).ToList();
            var accountTypes = _accountTypeQuery.GetEntities().ToList();
            foreach (var accountExtDto in list)
            {
                accountExtDto.AccountTypeName = accountTypes.Find(z => z.Id == accountExtDto.AccountTypeId).Name;
            }
            return list;
        }

        public IEnumerable<CheckBalanceDto> GetCheckBalanceItems()
        {
            var list = _transactionQuery.GetEntities()
                .Include(nameof(TransactionEntity.Bank))
                .Include(nameof(TransactionEntity.Account))
                .GroupBy(x => new { x.BankId, x.AccountId, x.CurrencyId })
                .Select(y => new CheckBalanceDto
                {
                    Id = y.FirstOrDefault().AccountId,
                    BankName = y.FirstOrDefault().Bank.Name,
                    AccountName = y.FirstOrDefault().Account.Name,
                    CurrencyId = y.Key.CurrencyId,
                    DbBalance = y.Sum(c => c.Dcc)
                }
                ).ToList();
            return list;
        }
    }
}