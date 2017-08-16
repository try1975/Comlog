using System.Data.Entity;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.QueryProcessors
{
    public class AccountQuery : TypedQuery<AccountEntity, int>, IAccountQuery
    {
        public AccountQuery(DbContext db) : base(db)
        {
        }
    }
}