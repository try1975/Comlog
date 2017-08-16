using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using ComLog.Db.Entities;
using ComLog.Db.MsSql;
using ComLog.Loader.Core;
using Demo.Ninject;

namespace ComLog.Loader
{
    public partial class Form1 : Form
    {
        private IExcelBookQuery ExcelBookQuery { get; }

        public Form1()
        {
            InitializeComponent();
            ExcelBookQuery = CompositionRoot.Resolve<IExcelBookQuery>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageWriter($"Количество записей в таблице импорта: {ExcelBookQuery.GetEntities().Count()}");

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            MessageWriter($"Импорт из файла: {openFileDialog.FileName}");
            var loaderSettings = new LoaderSettings
            {
                LoadedFilePath = openFileDialog.FileName,
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
