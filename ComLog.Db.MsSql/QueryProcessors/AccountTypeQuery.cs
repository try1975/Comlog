using System.Data.Entity;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.QueryProcessors
{
    public class AccountTypeQuery : TypedQuery<AccountTypeEntity, int>, IAccountTypeQuery
    {
        public AccountTypeQuery(DbContext db) : base(db)
        {
        }
    }
}