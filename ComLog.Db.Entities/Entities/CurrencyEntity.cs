using System;
using System.Collections.Generic;
using ComLog.Data.Interfaces;

namespace ComLog.Db.Entities
{
    public class CurrencyEntity : IEntity<string>, ITrackedEntity
    {
        public ICollection<AccountEntity> Accounts { get; set; }
        public ICollection<TransactionEntity> Transactions { get; set; }
        public string Id { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
        public int Ord { get; set; }
    }
}