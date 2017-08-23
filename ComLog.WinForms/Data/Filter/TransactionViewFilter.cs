using System;
using ComLog.WinForms.Interfaces.Filter;

namespace ComLog.WinForms.Data.Filter
{
    public class TransactionViewFilter : ITransactionViewFilter
    {
        private DateTime _dateFrom;
        private DateTime _dateTo;

        public TransactionViewFilter()
        {
            _dateFrom = Properties.Settings.Default.TransactionViewFilterDateFrom;
            _dateTo = Properties.Settings.Default.TransactionViewFilterDateTo;
        }

        public DateTime DateFrom
        {
            get { return _dateFrom == new DateTime() ? DateTime.Today : _dateFrom; }
            set
            {
                _dateFrom = value;
                Properties.Settings.Default.TransactionViewFilterDateFrom = _dateFrom;
                Properties.Settings.Default.Save();
            }
        }

        public DateTime DateTo
        {
            get { return _dateTo == new DateTime() ? DateTime.Today : _dateTo; }
            set
            {
                _dateTo = value;
                Properties.Settings.Default.TransactionViewFilterDateTo = _dateTo;
                Properties.Settings.Default.Save();
            }
        }
    }
}