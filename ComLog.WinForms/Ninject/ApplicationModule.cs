using System.Data.Entity;
using ComLog.Db.Entities;
using ComLog.Db.MsSql;
using ComLog.Db.MsSql.QueryProcessors;
using ComLog.WinForms.Controls;
using ComLog.WinForms.Data;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Data.Filter;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Interfaces.Filter;
using Ninject.Modules;

namespace ComLog.WinForms.Ninject
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataMаnager>().To<DataMаnager>().InSingletonScope();
            Bind<IComLogControl>().To<ComLogControl>().InSingletonScope();

            Bind<IAccountView>().To<AccountControl>();
            Bind<IAccountDataManager>().To<AccountDataManager>().InSingletonScope();

            Bind<IAccountTypeView>().To<AccountTypeControl>();
            Bind<IAccountTypeDataMаnager>().To<AccountTypeDataMаnager>().InSingletonScope();

            Bind<IBankView>().To<BankControl>();
            Bind<IBankDataMаnager>().To<BankDataMаnager>().InSingletonScope();

            Bind<ICurrencyView>().To<CurrencyControl>();
            Bind<ICurrencyDataMаnager>().To<CurrencyDataMаnager>().InSingletonScope();

            Bind<ITransactionTypeView>().To<TransactionTypeControl>();
            Bind<ITransactionTypeDataManager>().To<TransactionTypeDataManager>().InSingletonScope();

            Bind<ITransactionView>().To<TransactionControl>();
            Bind<ITransactionViewFilter>().To<TransactionViewFilter>();
            Bind<ITransactionDataManager>().To<TransactionDataManager>().InSingletonScope();

            // Loader
            Bind<DbContext>().To<WorkContext>().InSingletonScope();
            Bind<IExcelBookQuery>().To<ExcelBookQuery>().InSingletonScope();
        }
    }
}