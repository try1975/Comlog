using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ComLog.WinForms.Forms
{
    public partial class RunMacroForm : Form
    {
        private readonly string _loadCashUpdateXls;
        public RunMacroForm(string loadCashUpdateXls)
        {
            InitializeComponent();
            _loadCashUpdateXls = loadCashUpdateXls;
            label1.Text = _loadCashUpdateXls;
        }

        private void RunMacro()
        {
            //~~> Define your Excel Objects
            var xlApp = new Excel.Application();

            //~~> Start Excel and open the workbook.
            var xlWorkBook = xlApp.Workbooks.Open(@"C:\Projects\GitHub\ComLog\ComLog.WinForms\Macro\RunMacro.xlsm");

            //~~> Run the macros by supplying the necessary arguments
            xlApp.Run("ShowMsg", _loadCashUpdateXls, "Demo to run Excel macros from C#");

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
        }
    }
}
