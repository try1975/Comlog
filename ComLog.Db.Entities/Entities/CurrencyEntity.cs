using System.Collections.Generic;

namespace ComLog.Db.Entities
{
    public class CurrencyEntity : IEntity<string>
    {
        public ICollection<AccountEntity> Accounts { get; set; }
        public ICollection<TransactionEntity> Transactions { get; set; }
        public string Id { get; set; }
    }
}