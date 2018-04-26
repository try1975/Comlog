namespace ComLog.Dto.Ext
{
    public class TransactionExtDto : TransactionDto
    {
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string TransactionTypeName { get; set; }
        public string NewFormTypeName { get; set; }
        public bool? MsDaily01 { get; set; }
        public int CurrencyOrd { get; set; }
    }
}