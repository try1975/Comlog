using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ComLog.Db.Entities;
using ComLog.Db.MsSql;
using ComLog.Loader.Core;
using ComLog.WinForms.Ninject;
using ComLog.WinForms.Utils;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace ComLog.WinForms.Forms
{
    public partial class RunMacroForm : Form
    {
        private readonly MacroRunSettings _macroRunSettings;
        public bool NotShow { get; }

        public RunMacroForm(MacroRunSettings macroRunSettings)
        {
            InitializeComponent();
            _macroRunSettings = macroRunSettings;
            if (string.IsNullOrEmpty(_macroRunSettings.DestinationFilename)) return;
            if (!File.Exists(_macroRunSettings.DestinationFilename)) return;
            if (MessageBox.Show($@"Converted file {_macroRunSettings.DestinationFilename} already exists. Continue anyway?", @"Warning",
                    MessageBoxButtons.YesNo) == DialogResult.No) NotShow = true;
        }

        private void RunMacro()
        {
            #region create and open

            //~~> Define your Excel Objects
            var xlApp = new Application();

            //~~> Start Excel and open the workbook.
            //var pathPrefix = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)}\\{_macroRunSettings.MacroWorkBook}";
            //var path = new Uri($"{pathPrefix}").LocalPath;
            var path = Path.GetFullPath(_macroRunSettings.MacroWorkBook);
            var xlWorkBook = xlApp.Workbooks.Open(path);

            #endregion

            //~~> Run the macros by supplying the necessary arguments
            var cashUpdateMacro = ConfigurationManager.AppSettings[nameof(MacroSettings.CashUpdateMacro)];
            var cashMovementMacro = ConfigurationManager.AppSettings[nameof(MacroSettings.CashMovementMacro)];
            var msDailyMacro = ConfigurationManager.AppSettings[nameof(MacroSettings.MsDailyMacro)];
            var reportYMacro = ConfigurationManager.AppSettings[nameof(MacroSettings.ReportYMacro)];
            var cashListMacro = ConfigurationManager.AppSettings[nameof(MacroSettings.CashListMacro)];
            try
            {
                if (_macroRunSettings.MacroName.Equals(cashUpdateMacro))
                {
                    xlApp.Run(_macroRunSettings.MacroName, _macroRunSettings.SourceFilename, _macroRunSettings.DestinationFilename, DateTime.Today);
                }
                else if (_macroRunSettings.MacroName.Equals(cashMovementMacro))
                {
                    xlApp.Run(_macroRunSettings.MacroName, _macroRunSettings.SourceFilename, _macroRunSettings.DestinationFilename, DateTime.Today);
                }
                else if (_macroRunSettings.MacroName.Equals(cashListMacro))
                {
                    DateTime date;
                    if (!DateTime.TryParseExact(_macroRunSettings.Params["Date"], "yyyyMMdd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out date))
                    {
                        date = DateTime.Today;
                    }
                    date = date.Date;
                    var directoryName = Path.GetDirectoryName(path);
                    if (directoryName != null)
                    {
                        var filePath = Path.Combine(directoryName, $"Cl_{DateTime.UtcNow:yyyyMMdd_HHmm}.xlsx");
                        _macroRunSettings.DestinationFilename = filePath;
                        //_macroRunSettings.DestinationFilename = new Uri(filePath).LocalPath;
                    }
                    xlApp.Run(_macroRunSettings.MacroName, ConfigurationManager.AppSettings["ClPath"], _macroRunSettings.DestinationFilename, date);
                }
                else if (_macroRunSettings.MacroName.Equals(msDailyMacro))
                {
                    xlApp.Run(_macroRunSettings.MacroName, _macroRunSettings.SourceFilename, _macroRunSettings.DestinationFilename
                        , _macroRunSettings.Params["DTB"]
                        , _macroRunSettings.Params["DTE"]
                        , _macroRunSettings.Params["EUR_RATE"]
                        , _macroRunSettings.Params["GBP_RATE"]
                        , _macroRunSettings.Params["CHF_RATE"]
                        , _macroRunSettings.Params["EUR_RATE_P"]
                        , _macroRunSettings.Params["GBP_RATE_P"]
                        , _macroRunSettings.Params["CHF_RATE_P"]
                        );
                }
                else if (_macroRunSettings.MacroName.Equals(reportYMacro))
                {
                    xlApp.Run(_macroRunSettings.MacroName, _macroRunSettings.SourceFilename, _macroRunSettings.DestinationFilename, _macroRunSettings.Params["Period"]);
                }
                else
                {
                    xlApp.Run(_macroRunSettings.MacroName, _macroRunSettings.SourceFilename, _macroRunSettings.DestinationFilename);
                }
            }
            catch (Exception e)
            {
                MessageWriter(e.Message);
            }

            #region close and release

            //~~> Clean-up: Close the workbook
            xlWorkBook.Close(false);

            //~~> Quit the Excel Application
            xlApp.Quit();

            //~~> Clean Up
            ReleaseObject(xlApp);
            ReleaseObject(xlWorkBook);

            #endregion
        }

        //~~> Release the objects
        private static void ReleaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
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
            MessageWriter($"Started at {DateTime.Now}.");
            RunMacro();
            if (_macroRunSettings.Params.ContainsKey("ImportRun") && _macroRunSettings.Params["ImportRun"].Equals(bool.TrueString))
            {
                // load result to db
                ImportRun();
            }
            MessageWriter($"Completed at {DateTime.Now}.");
            btnOk.Enabled = true;
            btnOk.Focus();
            btnCancel.Enabled = false;
        }

        private void ImportRun()
        {
            var excelBookQuery = CompositionRoot.Resolve<IExcelBookQuery>();
            MessageWriter($"Количество записей в таблице импорта: {excelBookQuery.GetEntities().Count()}");
            MessageWriter($"Импорт из файла: {_macroRunSettings.DestinationFilename}");
            var loaderSettings = new LoaderSettings
            {
                LoadedFilePath = _macroRunSettings.DestinationFilename,
                SqlConnectionString = ConfigurationManager.ConnectionStrings["ComLog"].ConnectionString,
                BeforeLoadScriptFilename =
                    ConfigurationManager.AppSettings[nameof(LoaderSettings.BeforeLoadScriptFilename)],
                AfterLoadScriptFilename =
                    ConfigurationManager.AppSettings[nameof(LoaderSettings.AfterLoadScriptFilename)],
                BulkTableName = nameof(WorkContext.ExcelBooks),
                BulkSelectStatement = "Select * FROM [{0}]"
            };
            loaderSettings.OnMessage += MessageWriter;
            new LoaderAce(loaderSettings).Load();
            MessageWriter($"Количество записей в таблице импорта: {excelBookQuery.GetEntities().Count()}");
        }

        private void MessageWriter(string message)
        {
            tbMessages.AppendText(message);
            tbMessages.AppendText(Environment.NewLine);
        }
    }
}