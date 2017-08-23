using System;

namespace ComLog.WinForms.Interfaces.Filter
{
    public interface ITransactionViewFilter
    {
        DateTime DateFrom { get; set; }
        DateTime DateTo { get; set; }
    }
}