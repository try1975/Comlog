﻿using System;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using ComLog.WinForms.Administration;
using ComLog.WinForms.Ninject;
using log4net;

namespace ComLog.WinForms.Forms
{
    public partial class AuthenticationForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(nameof(AuthenticationForm));

        public AuthenticationForm()
        {
            InitializeComponent();
            tbLogin.Text = GetCurrentUserNameAsLogin();
        }

        private static string GetCurrentUserNameAsLogin()
        {
            try
            {
                var result = WindowsIdentity.GetCurrent().Name;
                Log.Debug($"WindowsIdentity.GetCurrent().Name {result}");
                var backSlashIndex = result.IndexOf("\\", StringComparison.Ordinal);
                if (backSlashIndex >= 0) result = result.Substring(backSlashIndex + 1);
                result = result.ToLower();
                Log.Debug($"result {result}");
                return result;
            }
            catch (Exception exception)
            {
                Log.Error(exception);
            }
            return string.Empty;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
#if DEBUG
            CurrentUser.Login = GetCurrentUserNameAsLogin();
            Log.Debug($"CurrentUser.Login {CurrentUser.Login}");
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