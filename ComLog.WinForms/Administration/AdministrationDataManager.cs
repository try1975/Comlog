using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using ComLog.WinForms.AdministrationServiceReference;

namespace ComLog.WinForms.Administration
{
    public class AdministrationDataManager : IDisposable
    {
        private AdministrationServiceClient _serviceClientInner;

        private AdministrationServiceClient ServiceClient
        {
            get
            {
                if (_serviceClientInner != null) return _serviceClientInner;
                _serviceClientInner = new AdministrationServiceClient();
                if (_serviceClientInner.ClientCredentials == null) return _serviceClientInner;
                _serviceClientInner.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                    X509CertificateValidationMode.None;
                _serviceClientInner.ClientCredentials.UserName.UserName = CurrentUser.Login;
                _serviceClientInner.ClientCredentials.UserName.Password = CurrentUser.Password;
                return _serviceClientInner;
            }
        }


        public void Dispose()
        {
            if (ServiceClient == null) return;
            try
            {
                ServiceClient.Close();
            }
            catch
            {
                ServiceClient.Abort();
            }
        }

        public string[] Authenticate(string login, string password)
        {
            try
            {
                return ServiceClient.Authenticate(login, password);
            }
            catch (MessageSecurityException)
            {
                return null;
            }
        }


        public User CreateUserInstance()
        {
            return new User();
        }

        public List<User> LoadUsers()
        {
            return ServiceClient.GetUsers().ToList();
        }

        public List<User> GetUsers()
        {
            return ListsCache.Users.Items;
        }

        public User GetUser(string id)
        {
            return ListsCache.Users.Items.FirstOrDefault(u => u.Id == id);
        }

        public string GetUserNameById(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return "";
            userId = userId.ToLower();
            var user = ListsCache.Users.GetItem(u => u.Id.ToLower() == userId);
            return user != null ? user.DisplayName : "<User was deleted>";
        }

        public string CreateUser(User user)
        {
            var id = ServiceClient.CreateUser(user);
            ListsCache.Users.InvalidateList();
            return id;
        }

        public bool UpdateUser(User user)
        {
            ServiceClient.UpdateUser(user);
            ListsCache.Users.InvalidateList();
            return true;
        }

        public bool DeleteUser(string userId)
        {
            var success = ServiceClient.DeleteUser(userId);
            ListsCache.Users.InvalidateList();
            return success;
        }


        public List<string> LoadRoles()
        {
            return ServiceClient.GetRoles().ToList();
        }

        public List<string> GetRoles()
        {
            return ListsCache.Roles.Items;
        }
    }
}