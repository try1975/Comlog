using System.Data.Entity;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.QueryProcessors
{
    public class DailyQuery : TypedQuery<DailyEntity, int>, IDailyQuery
    {
        public DailyQuery(DbContext db) : base(db)
        {
        }
    }
}