using ComLog.Dto;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Presenters.Common;

namespace ComLog.WinForms.Presenters
{
    public class BankPresenter : TypedPresenter<BankDto, int>
    {
        public BankPresenter(IBankView view, IBankDataMаnager typedDataMаnager, IDataMаnager dataMаnager)
            : base(view, typedDataMаnager, dataMаnager)
        {
        }
    }
}