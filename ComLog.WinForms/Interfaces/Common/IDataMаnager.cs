using System.Collections.Generic;
using System.Threading.Tasks;
using ComLog.Dto;

namespace ComLog.WinForms.Interfaces.Common
{
    public interface IDataMаnager
    {

        #region Banks

        Task<IEnumerable<BankDto>> GetBanks();
        Task<BankDto> GetBank(int id);
        Task<BankDto> PostBank(BankDto item);
        Task<BankDto> PutBank(BankDto item);
        Task<bool> DeleteBank(int id);

        #endregion //Banks

        #region Currencies

        Task<IEnumerable<CurrencyDto>> GetCurrencies();

        #endregion //Currencies

        #region Transactions
        Task<TransactionDto> PostTransaction(TransactionDto item);
        #endregion //Transactions
    }
}