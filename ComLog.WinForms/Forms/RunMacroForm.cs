using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ComLog.Db.Entities;
using ComLog.Db.MsSql;
using ComLog.Loader.Core;
using ComLog.WinForms.Ninject;
using ComLog.WinForms.Utils;
using Excel = Microsoft.Office.Interop.Excel;

namespace ComLog.WinForms.Forms
{
    public partial class RunMacroForm : Form
    {
        private readonly string _sourceFilename;
        private readonly string _destinationFilename;
        private readonly MacroRunSettings _macroRunSettings;
        public bool NotShow { get; }
        private IExcelBookQuery ExcelBookQuery { get; }

        public RunMacroForm(string sourceFilename, MacroRunSettings macroRunSettings)
        {
            InitializeComponent();
            ExcelBookQuery = CompositionRoot.Resolve<IExcelBookQuery>();
            _sourceFilename = sourceFilename;
            _destinationFilename = _sourceFilename.Replace(".xls", "_Converted.xls");
            _macroRunSettings = macroRunSettings;
            if (!File.Exists(_destinationFilename)) return;
            if (MessageBox.Show($"Converted file {_destinationFilename} already downloaded. Export anyway?", @"Warning", MessageBoxButtons.YesNo) == DialogResult.No) NotShow = true;
        }

        private void RunMacro()
        {
            //~~> Define your Excel Objects
            var xlApp = new Excel.Application();

            //~~> Start Excel and open the workbook.
            //var pathPrefix = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)}\\{_macroRunSettings.MacroWorkBook}";
            //var path = new Uri($"{pathPrefix}").LocalPath;
            var path = Path.GetFullPath(_macroRunSettings.MacroWorkBook);
            var xlWorkBook = xlApp.Workbooks.Open(path);

            //~~> Run the macros by supplying the necessary arguments
            if (
                _macroRunSettings.MacroName.Equals(
                    ConfigurationManager.AppSettings[nameof(MacroSettings.CashUpdateMacro)]))
            {
                xlApp.Run(_macroRunSettings.MacroName, _sourceFilename, _destinationFilename, DateTime.Today);
            }
            else
            {
                xlApp.Run(_macroRunSettings.MacroName, _sourceFilename, _destinationFilename);
            }

            //~~> Clean-up: Close the workbook
            xlWorkBook.Close(false);

            //~~> Quit the Excel Application
            xlApp.Quit();

            //~~> Clean Up
            ReleaseObject(xlApp);
            ReleaseObject(xlWorkBook);
        }

        //~~> Release the objects
        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void RunMacroForm_Shown(object sender, EventArgs e)
        {

            RunMacro();
            // load result to db
            LoadInDb();
        }

        private void LoadInDb()
        {
            MessageWriter($"Количество записей в таблице импорта: {ExcelBookQuery.GetEntities().Count()}");
            MessageWriter($"Импорт из файла: {_destinationFilename}");
            var loaderSettings = new LoaderSettings
            {
                LoadedFilePath = _destinationFilename,
                SqlConnectionString = ConfigurationManager.ConnectionStrings["ComLog"].ConnectionString,
                BeforeLoadScriptFilename = ConfigurationManager.AppSettings[nameof(LoaderSettings.BeforeLoadScriptFilename)],
                AfterLoadScriptFilename = ConfigurationManager.AppSettings[nameof(LoaderSettings.AfterLoadScriptFilename)],
                BulkTableName = nameof(WorkContext.ExcelBooks),
                BulkSelectStatement = "Select * FROM [{0}]"
            };
            loaderSettings.OnMessage += MessageWriter;
            new LoaderAce(loaderSettings).Load();
            MessageWriter($"Количество записей в таблице импорта: {ExcelBookQuery.GetEntities().Count()}");
        }
        private void MessageWriter(string message)
        {
            tbMessages.AppendText(message);
            tbMessages.AppendText(Environment.NewLine);
        }
    }
}
