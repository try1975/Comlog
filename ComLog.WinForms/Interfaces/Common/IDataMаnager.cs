using System.Collections.Generic;
using System.Threading.Tasks;
using ComLog.Dto;
using ComLog.Dto.Ext;

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
        Task<TransactionExtDto> PostTransaction(TransactionExtDto item);
        #endregion //Transactions
    }
}