using System;
using System.Windows.Forms;
using AutoMapper;
using AutoMapper.Configuration;
using ComLog.WinForms.Data;
using ComLog.WinForms.Ninject;

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
            var form = CompositionRoot.Resolve<Form1>();
            Application.Run(form);
        }
    }
}
