using System;
using System.Collections.Generic;
using ComLog.Dto.Ext;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms.Interfaces
{
    public interface ITransactionView : ITypedView<TransactionExtDto, int>
    {
        #region DetailsList

        List<AccountExtDto> AllAccountList { set; }
        List<AccountExtDto> NotClosedAccountList { set; }
        List<KeyValuePair<int, string>> TransactionTypeList { set; }

        #endregion DetailsList

        #region Details

        int BankId { get; set; }

        int AccountId { get; set; }

        int? TransactionTypeId { get; set; }

        string CurrencyId { get; set; }

        decimal? Credits { get; set; }

        decimal? Debits { get; set; }

        decimal? Charges { get; set; }

        string FromTo { get; set; }

        string Description { get; set; }

        decimal? UsdCredits { get; set; }

        decimal? UsdDebits { get; set; }

        string Report { get; set; }

        decimal? Dcc { get; set; }

        decimal? UsdDcc { get; set; }

        DateTime? TransactionDate { get; set; }

        #endregion //Details
    }
}