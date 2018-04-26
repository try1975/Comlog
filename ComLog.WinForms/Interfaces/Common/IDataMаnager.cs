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
        Task<IEnumerable<AccountMsDailyDto>> GetAccountsReport01(DateTime dateFrom, DateTime dateTo);
        #endregion //Accounts

        #region Banks

        Task<IEnumerable<BankDto>> GetBanks();

        #endregion //Banks

        #region Currencies

        Task<IEnumerable<CurrencyDto>> GetCurrencies();

        #endregion //Currencies

        #region Types

        Task<IEnumerable<TransactionTypeDto>> GetTransactionTypes();
        Task<IEnumerable<NewFormTypeDto>> GetNewFormTypes();

        #endregion //Types

        #region CurrencyExchangeRate

        Task<decimal> GetCurrencyExchangeRate(string currencyId, DateTime date);

        #endregion //CurrencyExchangeRate

        #region AccountTypes

        Task<IEnumerable<AccountTypeDto>> GetAccountTypes();

        #endregion //AccountTypes
    }
}