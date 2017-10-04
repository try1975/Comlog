using System;
using System.Security.Principal;
using System.Windows.Forms;
using ComLog.WinForms.Ninject;
using log4net;

namespace ComLog.WinForms.Administration
{
    public partial class AuthenticationForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AuthenticationForm()
        {
            InitializeComponent();
            tbLogin.Text = WindowsIdentity.GetCurrent().Name;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
#if DEBUG
            CurrentUser.Login = WindowsIdentity.GetCurrent().Name;
            var mainForm = CompositionRoot.Resolve<MainForm>();
            Hide();
            Log.Debug("Start mainform");
            mainForm.Show();
#else
            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show(@"Please enter login and password.");
                return;
            }
            using (var administrationDataManager = new AdministrationDataManager())
            {
                CurrentUser.Login = tbLogin.Text;
                CurrentUser.Password = tbPassword.Text;
                CurrentUser.Roles = administrationDataManager.Authenticate(tbLogin.Text, tbPassword.Text);
                if (CurrentUser.Roles == null)
                {
                    MessageBox.Show(@"Wrong login or password.");
                }
                else
                {
                    var mainForm = CompositionRoot.Resolve<MainForm>();
                    Hide();
                    mainForm.Show();
                }
            }
#endif
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
