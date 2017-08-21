namespace ComLog.Dto
{
    public class AccountDto : IDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BankId { get; set; }

        public string CurrencyId { get; set; }

        public int AccountTypeId { get; set; }
    }
}