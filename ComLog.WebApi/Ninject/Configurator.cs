using System.Data.Entity;
using AutoMapper;
using AutoMapper.Configuration;
using ComLog.Db.Entities;
using ComLog.Db.MsSql;
using ComLog.Db.MsSql.QueryProcessors;
using ComLog.WebApi.AutoMappers;
using ComLog.WebApi.Maintenance.Classes;
using ComLog.WebApi.Maintenance.Interfaces;
using Ninject;
using Ninject.Web.Common;

namespace ComLog.WebApi.Ninject
{
    /// <summary>
    ///     Class used to set up the Ninject DI container.
    /// </summary>
    public class Configurator
    {
        /// <summary>
        ///     Entry method used by caller to configure the given
        ///     container with all of this application's
        ///     dependencies.
        /// </summary>
        public static void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private static void AddBindings(IKernel container)
        {
            ConfigureOrm(container);
            ConfigureAutoMapper(container);

            #region Api and Query

            container.Bind<IAccountApi>().To<AccountApi>().InRequestScope();
            container.Bind<IAccountQuery>().To<AccountQuery>().InRequestScope();

            container.Bind<IAccountTypeApi>().To<AccountTypeApi>().InRequestScope();
            container.Bind<IAccountTypeQuery>().To<AccountTypeQuery>().InRequestScope();

            container.Bind<ICurrencyApi>().To<CurrencyApi>().InRequestScope();
            container.Bind<ICurrencyQuery>().To<CurrencyQuery>().InRequestScope();

            container.Bind<IBankApi>().To<BankApi>().InRequestScope();
            container.Bind<IBankQuery>().To<BankQuery>().InRequestScope();

            container.Bind<ITransactionApi>().To<TransactionApi>().InRequestScope();
            container.Bind<ITransactionQuery>().To<TransactionQuery>().InRequestScope();

            container.Bind<ITransactionTypeApi>().To<TransactionTypeApi>().InRequestScope();
            container.Bind<ITransactionTypeQuery>().To<TransactionTypeQuery>().InRequestScope();

            #endregion
        }

        private static void ConfigureAutoMapper(IKernel container)
        {
            var cfg = new MapperConfigurationExpression();
            AccountAutoMapper.Configure(cfg);
            AccountTypeAutoMapper.Configure(cfg);
            BankAutoMapper.Configure(cfg);
            CurrencyAutoMapper.Configure(cfg);
            TransactionAutoMapper.Configure(cfg);
            TransactionTypeAutoMapper.Configure(cfg);
            Mapper.Initialize(cfg);
            //Mapper.AssertConfigurationIsValid();
        }

        private static void ConfigureOrm(IKernel container)
        {
            container.Bind<DbContext>().To<WorkContext>().InRequestScope();
        }
    }
}