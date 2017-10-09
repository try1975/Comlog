using ComLog.Dto.Ext;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Filter;

namespace ComLog.WinForms.Interfaces.Data
{
    public interface IAccountDataManager : ITypedDataMаnager<AccountExtDto, int>
    {
        IAccountViewFilter AccountViewFilter { get; set; }
    }
}