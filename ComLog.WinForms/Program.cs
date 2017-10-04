using System;
using System.Windows.Forms;
using AutoMapper;
using AutoMapper.Configuration;
using ComLog.WinForms.Administration;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Ninject;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ComLog.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
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
    }
}
