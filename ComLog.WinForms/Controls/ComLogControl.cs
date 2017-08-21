using System.Windows.Forms;
using ComLog.WinForms.Forms;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Ninject;

namespace ComLog.WinForms.Controls
{
    public partial class ComLogControl : UserControl, IComLogControl
    {
        public ComLogControl()
        {
            InitializeComponent();
        }

        private void AddControlToWorkArea(Control control, bool ctrlPressed = false)
        {
            if (ctrlPressed)
            {
                var childForm = new ChildForm { Text = control.Name };
                childForm.AddControlToWorkArea(control);
                childForm.Show();
                return;
            }
            control.Dock = DockStyle.Fill;
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(control);
        }

        private void btnBanks_Click(object sender, System.EventArgs e)
        {
            var bankControl = CompositionRoot.Resolve<IBankView>();
            AddControlToWorkArea((Control)bankControl, ModifierKeys.HasFlag(Keys.Control));
        }
    }
}
