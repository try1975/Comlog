﻿namespace ComLog.Dto.Ext
{
    public class AccountMsDailyDto
    {
        public decimal? PrevBalance { get; set; }
        public string BankName { get; set; }
        public string CurrencyId { get; set; }
        public string FromTo { get; set; }
        public string Description { get; set; }
        public decimal? Dcc { get; set; }
        public decimal? Activity { get; set; }
        public decimal? NewBalance { get; set; }
    }
}