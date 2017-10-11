using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComLog.Dto;
using ComLog.Dto.Ext;

namespace ComLog.WinForms.Interfaces.Common
{
    public interface IDataMаnager
    {
        #region Accounts

        Task<IEnumerable<AccountExtDto>> GetAccounts();

        #endregion //Accounts

        #region Banks

        Task<IEnumerable<BankDto>> GetBanks();

        #endregion //Banks

        #region Currencies

        Task<IEnumerable<CurrencyDto>> GetCurrencies();

        #endregion //Currencies

        #region TransactionTypes

        Task<IEnumerable<TransactionTypeDto>> GetTransactionTypes();

        #endregion //TransactionTypes

        #region CurrencyExchangeRate

        Task<decimal> GetCurrencyExchangeRate(string currencyId, DateTime date);

        #endregion //CurrencyExchangeRate

        #region AccountTypes

        Task<IEnumerable<AccountTypeDto>> GetAccountTypes();

        #endregion //AccountTypes
    }
}