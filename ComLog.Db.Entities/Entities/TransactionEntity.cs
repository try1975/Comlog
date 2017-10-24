using System;
using ComLog.Data.Interfaces;

namespace ComLog.Db.Entities
{
    public class TransactionEntity : IEntity<int>, ITrackedEntity
    {
        public DateTime Dt { get; set; }

        public int BankId { get; set; }

        public int AccountId { get; set; }

        public int? TransactionTypeId { get; set; }

        public string CurrencyId { get; set; }

        public decimal? Credits { get; set; }

        public decimal? Debits { get; set; }

        public decimal? Charges { get; set; }

        public string FromTo { get; set; }

        public string Description { get; set; }

        public decimal? UsdCredits { get; set; }

        public decimal? UsdDebits { get; set; }

        public string Report { get; set; }

        public decimal? Dcc { get; private set; }

        public decimal? UsdDcc { get; private set; }

        public DateTime? TransactionDate { get; set; }

        public AccountEntity Account { get; set; }

        public BankEntity Bank { get; set; }

        public CurrencyEntity Currency { get; set; }

        public TransactionTypeEntity TransactionType { get; set; }
        public int Id { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
    }
}