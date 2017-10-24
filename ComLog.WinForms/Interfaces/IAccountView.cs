using System;
using System.Collections.Generic;
using ComLog.Data.Interfaces;
using ComLog.Dto.Ext;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms.Interfaces
{
    public interface IAccountView : ITypedView<AccountExtDto, int>, IAccount
    {
        #region Details

        string AccountName { get; set; }
        //decimal? Balance { get; set; }
        //int BankId { get; set; }
        //string CurrencyId { get; set; }
        //int AccountTypeId { get; set; }

        //DateTime? Closed { get; set; }
        //bool? MsDaily01 { get; set; }

        #endregion

        #region DetailsLists

        List<KeyValuePair<int, string>> BankList { set; }
        List<KeyValuePair<string, string>> CurrencyList { set; }
        List<KeyValuePair<int, string>> AccountTypeList { set; }

        #endregion

        #region Methods

        void HideAll();

        #endregion //Methods
    }
}