﻿using System;
using System.Collections.Generic;

namespace ComLog.Db.Entities
{
    public class AccountEntity : IEntity<int>, ITrackedEntity
    {
        public string Name { get; set; }

        public int BankId { get; set; }

        public string CurrencyId { get; set; }

        public int AccountTypeId { get; set; }

        public AccountTypeEntity AccountType { get; set; }

        public BankEntity Bank { get; set; }

        public CurrencyEntity Currency { get; set; }

        public DateTime? Closed { get; set; }

        public ICollection<TransactionEntity> Transactions { get; set; }
        public ICollection<ExcelBookEntity> ExcelBooks { get; set; }
        public int Id { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
    }
}