namespace ComLog.Dto.Ext
{
    public class AccountExtDto : AccountDto
    {
        public string BankName { get; set; }
        public string AccountTypeName { get; set; }

        public string DisplayMember => $"{Name} [{BankName} {CurrencyId}]";
    }
}