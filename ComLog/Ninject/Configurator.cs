using System.Data.Entity;
using AutoMapper;
using AutoMapper.Configuration;
using ComLog.AutoMappers;
using ComLog.Db.Entities;
using ComLog.Db.MsSql;
using ComLog.Db.MsSql.QueryProcessors;
using ComLog.Maintenance;
using Ninject;
using Ninject.Web.Common;

namespace ComLog.Ninject
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
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            ConfigureOrm(container);
            ConfigureAutoMapper(container);

            #region Api and Query

            //container.Bind<ICurrencyApi>().To<CurrencyApi>().InRequestScope();
            container.Bind<ICurrencyQuery>().To<CurrencyQuery>().InRequestScope();

            container.Bind<IBankApi>().To<BankApi>().InRequestScope();
            container.Bind<IBankQuery>().To<BankQuery>().InRequestScope();

            //container.Bind<IAccountApi>().To<AccountApi>().InRequestScope();
            container.Bind<IAccountQuery>().To<AccountQuery>().InRequestScope();

            container.Bind<ITransactionApi>().To<TransactionApi>().InRequestScope();
            container.Bind<ITransactionQuery>().To<TransactionQuery>().InRequestScope();

            #endregion
        }

        private void ConfigureAutoMapper(IKernel container)
        {
            var cfg = new MapperConfigurationExpression();
            BankAutoMapper.Configure(cfg);
            //BankAccountAutoMapper.Configure(cfg);
            //CurrencyAutoMapper.Configure(cfg);
            //ClientAutoMapper.Configure(cfg);
            //CardAutoMapper.Configure(cfg);
            //AccountAutoMapper.Configure(cfg);
            //MessageAutoMapper.Configure(cfg);
            //RequisiteAutoMapper.Configure(cfg);
            //RequestAutoMapper.Configure(cfg);
            //StandingOrderAutoMapper.Configure(cfg);
            //StatementAutoMapper.Configure(cfg);
            TransactionAutoMapper.Configure(cfg);
            //DirectDebitAutoMapper.Configure(cfg);
            Mapper.Initialize(cfg);
            //Mapper.AssertConfigurationIsValid();


            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<ClientToClientEntityAutoMapperTypeConfigurator>()
            //    .InRequestScope/*InSingletonScope*/();
        }

        private void ConfigureOrm(IKernel container)
        {
            //container.Bind<WorkContext>().ToSelf().InRequestScope();
            container.Bind<DbContext>().To<WorkContext>().InSingletonScope();
            //container.Bind<ExchangeServiceMailSender>().ToSelf().InSingletonScope();
        }
    }
}