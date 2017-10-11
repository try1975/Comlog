using ComLog.WinForms.AdministrationServiceReference;

namespace ComLog.WinForms.Administration
{
    internal static class ListsCache
    {
        private static CachedList<User> _users;

        private static CachedList<string> _roles;

        public static CachedList<User> Users
        {
            get
            {
                return _users ?? (_users = new CachedList<User>(() =>
                {
                    using (var dataManager = new AdministrationDataManager())
                    {
                        return dataManager.LoadUsers();
                    }
                }));
            }
        }

        public static CachedList<string> Roles
        {
            get
            {
                return _roles ?? (_roles = new CachedList<string>(() =>
                {
                    using (var dataManager = new AdministrationDataManager())
                    {
                        return dataManager.LoadRoles();
                    }
                }));
            }
        }
    }
}