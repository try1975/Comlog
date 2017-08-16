using System.Data.Entity;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.QueryProcessors
{
    public class BankQuery : TypedQuery<BankEntity, int>, IBankQuery
    {
        public BankQuery(DbContext db) : base(db)
        {
        }
    }
}