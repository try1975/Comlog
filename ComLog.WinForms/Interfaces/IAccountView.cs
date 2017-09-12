using System;
using System.Collections.Generic;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms.Interfaces
{
    public interface IAccountView : ITypedView<AccountExtDto, int>
    {
        #region Details

        string Name { get; set; }
        int BankId { get; set; }
        string CurrencyId { get; set; }
        int AccountTypeId { get; set; }

        DateTime? Closed { get; set; }

        #endregion

        #region DetailsLists

        List<KeyValuePair<int, string>> BankList { set; }
        List<KeyValuePair<string, string>> CurrencyList { set; }
        List<KeyValuePair<int, string>> AccountTypeList { set; }

        #endregion
    }
}