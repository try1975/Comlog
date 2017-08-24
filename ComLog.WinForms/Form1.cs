using System.Windows.Forms;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms
{
    public partial class Form1 : Form
    {
        public Form1(IComLogControl comLogControl)
        {
            InitializeComponent();

            var control = (Control)comLogControl;
            control.Dock = DockStyle.Fill;
            panel1.Controls.Add(control);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
