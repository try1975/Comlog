using System.Data.Entity;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.QueryProcessors
{
    public class CurrencyQuery : TypedQuery<CurrencyEntity, string>, ICurrencyQuery
    {
        public CurrencyQuery(DbContext db) : base(db)
        {
        }
    }
}