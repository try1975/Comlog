using System;

namespace ComLog.Dto.Ext
{
    public class CheckBalanceDto : IDto<int>, ITrackedDto
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string CurrencyId { get; set; }
        public decimal? DbBalance { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
    }
}