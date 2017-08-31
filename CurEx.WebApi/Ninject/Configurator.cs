using System.Data.Entity;
using AutoMapper;
using AutoMapper.Configuration;
using CurEx.Db.Entities.QueryProcessors;
using CurEx.Db.MsSql;
using CurEx.Db.MsSql.QueryProcessors;
using CurEx.WebApi.AutoMappers;
using CurEx.WebApi.Maintenance.Classes;
using CurEx.WebApi.Maintenance.Interfaces;
using Ninject;
using Ninject.Web.Common;

namespace CurEx.WebApi.Ninject
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

            container.Bind<ICurrencyPairApi>().To<CurrencyPairApi>().InRequestScope();
            container.Bind<ICurrencyPairQuery>().To<CurrencyPairQuery>().InRequestScope();

            container.Bind<ICurrencyPairRateApi>().To<CurrencyPairRateApi>().InRequestScope();
            container.Bind<ICurrencyPairRateQuery>().To<CurrencyPairRateQuery>().InRequestScope();

            container.Bind<ICurrencyRateApi>().To<CurrencyRateApi>().InRequestScope();

            #endregion
        }

        private void ConfigureAutoMapper(IKernel container)
        {
            var cfg = new MapperConfigurationExpression();
            CurrencyPairRateMapper.Configure(cfg);
            CurrencyPairMapper.Configure(cfg);
            Mapper.Initialize(cfg);
            //Mapper.AssertConfigurationIsValid();


            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<ClientToClientEntityAutoMapperTypeConfigurator>()
            //    .InRequestScope/*InSingletonScope*/();
        }

        private void ConfigureOrm(IKernel container)
        {
            //container.Bind<WorkContext>().ToSelf().InRequestScope();
            container.Bind<DbContext>().To<CurExContext>().InSingletonScope();
            //container.Bind<ExchangeServiceMailSender>().ToSelf().InSingletonScope();
        }
    }
}