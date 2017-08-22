using System.Data.Entity;
using CurEx.Db.Entities.Entities;
using CurEx.Db.Entities.QueryProcessors;

namespace CurEx.Db.MsSql.QueryProcessors
{
    public class CurrencyPairRateQuery : TypedQuery<CurrencyPairRateEntity, int>, ICurrencyPairRateQuery
    {
        public CurrencyPairRateQuery(DbContext db) : base(db)
        {
        }
    }
}