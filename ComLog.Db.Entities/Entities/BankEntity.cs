using System;
using System.Collections.Generic;

namespace ComLog.Db.Entities
{
    public class BankEntity : IEntity<int>, ITrackedEntity
    {
        public string Name { get; set; }

        public DateTime? Closed { get; set; }

        public ICollection<ExcelBookEntity> ExcelBooks { get; set; }
        public ICollection<AccountEntity> Accounts { get; set; }
        public ICollection<TransactionEntity> Transactions { get; set; }
        public int Id { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
    }
}