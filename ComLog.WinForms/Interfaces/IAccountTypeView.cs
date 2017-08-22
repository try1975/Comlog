using ComLog.Dto;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms.Interfaces
{
    public interface IAccountTypeView : ITypedView<AccountTypeDto, int>
    {
        #region Details

        string AccountTypeName { get; set; }

        #endregion //Details
    }
}