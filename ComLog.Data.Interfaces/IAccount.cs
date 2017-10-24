using System;

namespace ComLog.Data.Interfaces
{
    public interface IAccount
    {
        string Name { get; set; }
        decimal? Balance { get; set; }
        int BankId { get; set; }
        string CurrencyId { get; set; }
        int AccountTypeId { get; set; }
        int? DailyId { get; set; }
        DateTime? Closed { get; set; }
        bool? MsDaily01 { get; set; }
    }
}