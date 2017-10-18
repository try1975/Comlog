using System;

namespace ComLog.Dto
{
    public class AccountDto : IDto<int>, ITrackedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal? Balance { get; set; }

        public int BankId { get; set; }

        public string CurrencyId { get; set; }

        public int AccountTypeId { get; set; }

        public DateTime? Closed { get; set; }
        public bool? MsDaily01 { get; set; }
        public string ChangeBy { get; set; }
        public DateTime? ChangeAt { get; set; }
    }
}