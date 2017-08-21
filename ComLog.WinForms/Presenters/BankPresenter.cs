using ComLog.Dto;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Data;

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