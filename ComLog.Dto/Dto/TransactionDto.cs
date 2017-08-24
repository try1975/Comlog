using System;

namespace ComLog.Dto
{
    public class TransactionDto : IDto<int>
    {
        public DateTime TransactionDate { get; set; }

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

        public decimal? Dcc { get; set; }

        public decimal? UsdDcc { get; set; }

        public int Id { get; set; }
    }
}