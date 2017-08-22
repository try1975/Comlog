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

        private void btnAccounts_Click(object sender, System.EventArgs e)
        {
            var accountControl = CompositionRoot.Resolve<IAccountView>();
            AddControlToWorkArea((Control)accountControl, ModifierKeys.HasFlag(Keys.Control));
        }

        private void btnCurrencies_Click(object sender, System.EventArgs e)
        {
            var currencyControl = CompositionRoot.Resolve<ICurrencyView>();
            AddControlToWorkArea((Control)currencyControl, ModifierKeys.HasFlag(Keys.Control));
        }

        private void btnAccountTypes_Click(object sender, System.EventArgs e)
        {
            var accountTypeControl = CompositionRoot.Resolve<IAccountTypeView>();
            AddControlToWorkArea((Control)accountTypeControl, ModifierKeys.HasFlag(Keys.Control));
        }

        private void btnTransactionTypes_Click(object sender, System.EventArgs e)
        {
            var transactionTypeControl = CompositionRoot.Resolve<ITransactionTypeView>();
            AddControlToWorkArea((Control)transactionTypeControl, ModifierKeys.HasFlag(Keys.Control));
        }

        private void btnTransactions_Click(object sender, System.EventArgs e)
        {
            var transactionControl = CompositionRoot.Resolve<ITransactionView>();
            AddControlToWorkArea((Control)transactionControl, ModifierKeys.HasFlag(Keys.Control));
        }
    }
}
