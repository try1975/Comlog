using System;
using System.Windows.Forms;
using AutoMapper;
using AutoMapper.Configuration;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Forms;
using ComLog.WinForms.Ninject;
using log4net;
using log4net.Config;

[assembly: XmlConfigurator(Watch = true)]

namespace ComLog.WinForms
{
    internal static class Program
    {

        private static readonly ILog Log = LogManager.GetLogger(nameof(Program));
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                CompositionRoot.Wire(new ApplicationModule());
                var cfg = new MapperConfigurationExpression();
                AutoMapperConfig.RegisterMappings(cfg);
                Mapper.Initialize(cfg);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //var form = CompositionRoot.Resolve<MainForm>();
                //Application.Run(form);
                Application.Run(new AuthenticationForm());
            }
            catch (Exception exception)
            {
                Log.Error(exception);
                throw;
            }
        }
    }
}