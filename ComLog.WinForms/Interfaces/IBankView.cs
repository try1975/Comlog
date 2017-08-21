using ComLog.Dto;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms.Interfaces
{
    public interface IBankView : ITypedView<BankDto, int>
    {
        #region Details

        string BankName { get; set; }

        #endregion //Details
    }
}