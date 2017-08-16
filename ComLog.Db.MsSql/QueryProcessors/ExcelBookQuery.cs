using System.Data.Entity;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.QueryProcessors
{
    public class ExcelBookQuery : TypedQuery<ExcelBookEntity, int>, IExcelBookQuery
    {
        public ExcelBookQuery(DbContext db) : base(db)
        {
        }
    }
}