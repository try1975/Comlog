using ComLog.Dto;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms.Interfaces
{
    public interface ITransactionTypeView : ITypedView<TransactionTypeDto, int>
    {
        #region Details

        string TransactionTypeName { get; set; }

        #endregion //Details
    }
}