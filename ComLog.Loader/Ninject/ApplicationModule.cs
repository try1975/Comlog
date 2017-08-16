using System.Data.Entity;
using ComLog.Db.Entities;
using ComLog.Db.MsSql;
using ComLog.Db.MsSql.QueryProcessors;
using Ninject.Modules;

namespace ComLog.Loader.Ninject
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<WorkContext>().InSingletonScope();
            Bind<IExcelBookQuery>().To<ExcelBookQuery>().InSingletonScope();
        }
    }
}