namespace ComLog.Dto.Ext
{
    public class AccountExtDto : AccountDto
    {
        public string BankName { get; set; }
        public string AccountTypeName { get; set; }
        public decimal? DbBalance { get; set; }
        public decimal? DeltaBalance { get; set; }
        public bool? MsDaily01 { get; set; }
        public string DisplayMember
        {
            get { return $"{BankName} [{Name}] [{CurrencyId}]"; }
            set
            {
                ;
            }
        }
    }
}