using System;
using System.Configuration;
using System.Linq;
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
        private readonly MacroSettings _macroSettings;
        private IExcelBookQuery ExcelBookQuery { get; }

        public RunMacroForm(string sourceFilename, MacroSettings macroSettings)
        {
            InitializeComponent();
            ExcelBookQuery = CompositionRoot.Resolve<IExcelBookQuery>();
            _sourceFilename = sourceFilename;
            _destinationFilename = _sourceFilename.Replace(".xls", "_Converted.xls");
            _macroSettings = macroSettings;
        }

        private void RunMacro()
        {
            //~~> Define your Excel Objects
            var xlApp = new Excel.Application();

            //~~> Start Excel and open the workbook.
            var xlWorkBook = xlApp.Workbooks.Open(_macroSettings.MacroWorkBook);

            //~~> Run the macros by supplying the necessary arguments
            xlApp.Run(_macroSettings.CashUpdateMacro, _sourceFilename, _destinationFilename);

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
