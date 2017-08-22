using ComLog.Common;
using ComLog.Dto;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class TransactionTypeDataManager : TypedDataMаnager<TransactionTypeDto, int>, ITransactionTypeDataManager
    {
        public TransactionTypeDataManager() : base(ComLogConstants.ClientAppApi.TransactionTypes)
        {
        }
    }
}