using System;
using ComLog.Data.Interfaces;

namespace ComLog.Db.Entities
{
    public class ExcelBookEntity : IEntity<int>
    {
        public DateTime? Dt { get; set; }

        public string BankName { get; set; }

        public string AccountName { get; set; }

        public string AccountTypeName { get; set; }

        public string CurrencyId { get; set; }

        public decimal? Credits { get; set; }

        public decimal? Debits { get; set; }

        public decimal? Charges { get; set; }

        public string FromTo { get; set; }

        public string Description { get; set; }

        public string Report { get; set; }

        public string TrType { get; set; }

        public decimal? Splus { get; set; }

        public decimal? Sminus { get; set; }

        public decimal? Ssum { get; set; }

        public int? BankId { get; set; }
        public BankEntity Bank { get; set; }

        public int? AccountId { get; set; }
        public AccountEntity Account { get; set; }

        public int? AccountTypeId { get; set; }
        public AccountTypeEntity AccountType { get; set; }

        public int? TransactionTypeId { get; set; }
        public TransactionTypeEntity TransactionType { get; set; }
        public int Id { get; set; }
    }
}