namespace ComLog.Dto.Ext
{
    public class AccountBalanceDto
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string DailyName { get; set; }
        public string CurrencyId { get; set; }
        public int CurrencyOrd { get; set; }
        public decimal PrevBalance { get; set; }
        public decimal Activity { get; set; }
        public decimal NewBalance { get; set; }

    }
}