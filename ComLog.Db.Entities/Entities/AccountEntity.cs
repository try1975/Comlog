using System;
using System.Collections.Generic;
using ComLog.Data.Interfaces;

namespace ComLog.Db.Entities
{
    public class AccountEntity : IEntity<int>, IAccount, ITrackedEntity
    {
        public string Name { get; set; }

        public decimal? Balance { get; set; }

        public int BankId { get; set; }

        public string CurrencyId { get; set; }

        public int AccountTypeId { get; set; }
        

        public AccountTypeEntity AccountType { get; set; }

        public BankEntity Bank { get; set; }

        public CurrencyEntity Currency { get; set; }

        public int? DailyId { get; set; }
        public DailyEntity Daily { get; set; }

        public DateTime? Closed { get; set; }

        public bool? MsDaily01 { get; set; } 

        public ICollection<TransactionEntity> Transactions { get; set; }
        public ICollection<ExcelBookEntity> ExcelBooks { get; set; }
        public int Id { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
    }
}