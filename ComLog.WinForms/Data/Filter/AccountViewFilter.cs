using ComLog.WinForms.Interfaces.Filter;

namespace ComLog.WinForms.Data.Filter
{
    public class AccountViewFilter : IAccountViewFilter
    {
        public bool ShowClosed { get; set; }
    }
}