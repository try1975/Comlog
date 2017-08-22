using System.Data.Entity;
using CurEx.Db.Entities.Entities;
using CurEx.Db.Entities.QueryProcessors;

namespace CurEx.Db.MsSql.QueryProcessors
{
    public class CurrencyPairQuery : TypedQuery<CurrencyPairEntity, string>, ICurrencyPairQuery
    {
        public CurrencyPairQuery(DbContext db) : base(db)
        {
        }
    }
}