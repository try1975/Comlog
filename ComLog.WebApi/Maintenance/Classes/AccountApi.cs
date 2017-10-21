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
                 .Include(nameof(AccountEntity.Currency))
                 .OrderBy(z => z.Bank.Name)
                 .ThenBy(z => z.Currency.Ord)
                 .ThenBy(z => z.Name)
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
                    Balance = o.account.Balance ?? 0,
                    BankId = o.account.BankId,
                    CurrencyId = o.account.CurrencyId,
                    AccountTypeId = o.account.AccountTypeId,
                    Closed = o.account.Closed,
                    ChangeBy = o.account.ChangeBy,
                    ChangeAt = o.account.ChangeAt,
                    BankName = o.account.Bank.Name,
                    AccountTypeName = o.account.AccountType.Name,
                    DbBalance = o.balance == null ? 0 : o.balance.DbBalance,
                    DeltaBalance = (o.account.Balance ?? 0) - (o.balance == null ? 0 : o.balance.DbBalance),
                    MsDaily01 = o.account.MsDaily01
                })
                .ToList();
            return list;
        }

        public IEnumerable<AccountMsDailyDto> GetMsDaily(DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var accounts = Query.GetEntities()
                    .Include(nameof(AccountEntity.Bank))
                    .Include(nameof(AccountEntity.Currency))
                    .Include(nameof(AccountEntity.Daily))
                    .Where(z => z.MsDaily01 == true)
                    .Select(z => new AccountBalanceDto
                    {
                        Id = z.Id,
                        BankName = z.Bank.Name,
                        DailyName = z.Daily == null ? z.Bank.Name : z.Daily.Name,
                        CurrencyId = z.CurrencyId,
                        CurrencyOrd = z.Currency.Ord
                    })
                    .OrderBy(z => z.DailyName)
                    .ThenBy(z => z.CurrencyOrd)
                    .ToList()
                ;
            var accountIds = accounts.Select(z => z.Id).ToList();
            var aDateFrom = dateFrom?.Date ?? DateTime.Today.Date;
            var aDateTo = dateTo?.Date.AddDays(1) ?? DateTime.Today.Date.AddDays(1);
            var prevBalances = _transactionQuery.GetEntities()
                    .Where(z => z.TransactionDate < aDateFrom && accountIds.Contains(z.AccountId))
                    .GroupBy(x => new { x.AccountId })
                    .Select(y => new
                    {
                        Id = y.Key.AccountId,
                        DbBalance = y.Sum(c => c.Dcc)
                    })
                    .ToList()
                ;
            var activities = _transactionQuery.GetEntities()
                    .Where(z => z.TransactionDate >= aDateFrom && z.TransactionDate < aDateTo && accountIds.Contains(z.AccountId))
                    .GroupBy(x => new { x.AccountId })
                    .Select(y => new
                    {
                        Id = y.Key.AccountId,
                        DbBalance = y.Sum(c => c.Dcc)
                    })
                    .ToList()
                ;
            foreach (var accountBalanceDto in accounts)
            {
                accountBalanceDto.PrevBalance = prevBalances.Where(z => z.Id == accountBalanceDto.Id).Sum(z => z.DbBalance) ?? 0;
                accountBalanceDto.Activity = activities.Where(z => z.Id == accountBalanceDto.Id).Sum(z => z.DbBalance) ?? 0;
                accountBalanceDto.NewBalance = accountBalanceDto.PrevBalance + accountBalanceDto.Activity;
            }

            var daily = accounts
                    .GroupBy(z => new { z.DailyName, z.CurrencyId })
                    .Select(z => new AccountMsDailyDto
                    {
                        BankName = z.Key.DailyName,
                        CurrencyId = z.Key.CurrencyId,
                        PrevBalance = z.Sum(y => y.PrevBalance),
                        Activity = z.Sum(y => y.Activity),
                        NewBalance = z.Sum(y => y.NewBalance)
                    })
                    .ToList()
                ;
            var transactions = _transactionQuery.GetEntities()
                    .Where(z => z.TransactionDate >= aDateFrom && z.TransactionDate < aDateTo && accountIds.Contains(z.AccountId))
                    .ToList()
                ;
            var dailyNew = new List<AccountMsDailyDto>();
            foreach (var dto in daily)
            {
                var accountsGroupIds = accounts.Where(z => z.DailyName == dto.BankName).Select(z => z.Id).ToList();
                var bankAndCurrencyTransactions = transactions.Where(z =>
                    accountsGroupIds.Contains(z.AccountId) && z.CurrencyId == dto.CurrencyId).ToList();
                if (bankAndCurrencyTransactions.Count > 0)
                {
                    var firstTime = true;
                    for (var i = 0; i < bankAndCurrencyTransactions.Count; i++)
                    {
                        if (firstTime)
                        {
                            dto.FromTo = bankAndCurrencyTransactions[i].FromTo;
                            dto.Description = bankAndCurrencyTransactions[i].Description;
                            dto.Dcc = bankAndCurrencyTransactions[i].Dcc ?? 0;

                            dailyNew.Add(dto);
                        }
                        else
                        {
                            dailyNew.Add(new AccountMsDailyDto
                            {
                                BankName = dto.BankName,
                                CurrencyId = dto.CurrencyId,
                                FromTo = bankAndCurrencyTransactions[i].FromTo,
                                Description = bankAndCurrencyTransactions[i].Description,
                                Dcc = bankAndCurrencyTransactions[i].Dcc ?? 0
                            });
                        }
                        if (i == 0)
                        {
                            firstTime = false;
                        }

                    }
                }
                else
                {
                    dailyNew.Add(dto);
                }
            }
            return dailyNew;
        }

    }
}