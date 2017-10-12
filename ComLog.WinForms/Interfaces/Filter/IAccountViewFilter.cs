namespace ComLog.WinForms.Interfaces.Filter
{
    public interface IAccountViewFilter
    {
        bool ShowClosed { get; set; }
        bool OnlyTodayActivity { get; set; }
    }
}