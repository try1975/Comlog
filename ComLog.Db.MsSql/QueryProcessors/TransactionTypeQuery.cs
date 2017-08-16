using System.Data.Entity;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.QueryProcessors
{
    public class TransactionTypeQuery: TypedQuery<TransactionTypeEntity,int>, ITransactionTypeQuery
    {
        public TransactionTypeQuery(DbContext db) : base(db)
        {
        }
    }
}