using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Filter;

namespace ComLog.WinForms.Interfaces.Data
{
    public interface ITransactionDataManager : ITypedDataMаnager<TransactionExtDto, int>
    {
        ITransactionViewFilter TransactionViewFilter { get; set; }
    }
}