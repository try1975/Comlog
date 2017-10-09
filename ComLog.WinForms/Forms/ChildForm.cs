using System.Windows.Forms;
using ComLog.WinForms.Interfaces;

namespace ComLog.WinForms.Forms
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        public void AddControlToWorkArea(Control control)
        {
            control.Dock = DockStyle.Fill;
            Controls.Clear();
            Controls.Add(control);
        }

        public void ReopenData()
        {
            foreach (Control control in Controls)
            {
                if (!(control is IAccountView)) continue;
                (control as IAccountView).Reopen();
                break;
            }
        }
    }
}