using System.Data.Entity;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.QueryProcessors
{
    public class NewFormTypeQuery : TypedQuery<NewFormTypeEntity, int>, INewFormTypeQuery
    {
        public NewFormTypeQuery(DbContext db) : base(db)
        {
        }
    }
}