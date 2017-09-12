using System.Windows.Forms;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm(IComLogControl comLogControl)
        {
            InitializeComponent();

            var control = (Control)comLogControl;
            control.Dock = DockStyle.Fill;
            panel1.Controls.Add(control);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Exit();
        }
    }
}
