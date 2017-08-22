using System;
using System.Collections.Generic;
using ComLog.Dto;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms.Interfaces
{
    public interface IAccountView : ITypedView<AccountDto, int>
    {
        #region Details

        string BankAccountName { get; set; }
        int BankId { get; set; }
        string CurrencyId { get; set; }
        string BeneficiaryAddress { get; set; }

        #endregion

        #region DetailsLists

        List<KeyValuePair<int, string>> BankList { set; }
        List<KeyValuePair<string, string>> CurrencyList { set; }

        #endregion
    }
}