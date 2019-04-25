using System;

namespace ComLog.Dto.Ext
{
    public class TransactionReport01Dto
    {
        private DateTime? _weekDt;
        public DateTime TransactionDate { get; set; }

        public string BankName { get; set; }

        public string AccountName { get; set; }

        public string TransactionTypeName { get; set; }

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

        public DateTime? WeekDt
        {
            get => _weekDt ?? TransactionDate;
            set => _weekDt = value;
        }
    }
}