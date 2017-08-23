namespace ComLog.Dto.Ext
{
    public class TransactionExtDto : TransactionDto
    {
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string TransactionTypeName { get; set; }
    }
}