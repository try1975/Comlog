using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ComLog.Common;
using ComLog.Dto.Ext;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Interfaces.Filter;

namespace ComLog.WinForms.Data
{
    public class AccountDataManager : TypedDataMаnager<AccountExtDto, int>, IAccountDataManager
    {
        private readonly ITransactionDataManager _transactionDataManager;
        public AccountDataManager(IAccountViewFilter accountViewFilter, ITransactionDataManager transactionDataManager) : base(ComLogConstants.ClientAppApi.Accounts)
        {
            AccountViewFilter = accountViewFilter;
            _transactionDataManager= transactionDataManager;
        }

        public IAccountViewFilter AccountViewFilter { get; set; }

        public override async Task<IEnumerable<AccountExtDto>> GetItems()
        {
            using (var response = await HttpClient.GetAsync($"{EndPoint}?withBalance=true"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<IEnumerable<AccountExtDto>>();
                if (!AccountViewFilter.ShowClosed) result = result.Where(z => z.Closed == null);
                if (AccountViewFilter.OnlyTodayActivity)
                {
                    _transactionDataManager.TransactionViewFilter.DateFrom=DateTime.Today;
                    _transactionDataManager.TransactionViewFilter.DateTo = DateTime.Today;
                    var transactions = await _transactionDataManager.GetItems();
                    var todayActivityAccounts = transactions.Select(z => z.AccountId).Distinct().ToList();
                    result = result.Where(z => todayActivityAccounts.Contains(z.Id));
                }
                return result;
            }
        }
    }
}