using System.Data.Entity;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.QueryProcessors
{
    public class TransactionQuery : TypedQuery<TransactionEntity, int>, ITransactionQuery
    {
        public TransactionQuery(DbContext db) : base(db)
        {
        }
    }
}