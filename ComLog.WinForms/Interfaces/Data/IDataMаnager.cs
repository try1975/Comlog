using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComLog.Dto;

namespace ComLog.WinForms.Interfaces.Data
{
    public interface IDataMаnager
    {
        #region Currencies

        //Task<IEnumerable<CurrencyDto>> GetCurrencies();

        #endregion //Currencies

        #region Banks

        Task<IEnumerable<BankDto>> GetBanks();
        Task<BankDto> GetBank(Guid id);
        //Task<Bank> GetBank(Uri uri);
        Task<BankDto> PostBank(BankDto item);
        Task<BankDto> PutBank(BankDto item);
        Task<bool> DeleteBank(Guid id);

        #endregion //Banks


        #region Transactions
        Task<TransactionDto> PostTransaction(TransactionDto item);
        #endregion //Transactions
    }
}