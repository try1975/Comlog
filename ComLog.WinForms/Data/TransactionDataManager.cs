using ComLog.Common;
using ComLog.Dto;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class TransactionDataManager : TypedDataMаnager<TransactionDto, int>, ITransactionDataManager
    {
        public TransactionDataManager() : base(ComLogConstants.ClientAppApi.Transactions)
        {
        }
    }
}