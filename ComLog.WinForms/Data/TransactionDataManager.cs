using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ComLog.Common;
using ComLog.Dto.Ext;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Interfaces.Filter;
using log4net;

namespace ComLog.WinForms.Data
{
    public class TransactionDataManager : TypedDataMаnager<TransactionExtDto, int>, ITransactionDataManager
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ITransactionViewFilter TransactionViewFilter { get; set; }

        public TransactionDataManager(ITransactionViewFilter transactionViewFilter) : base(ComLogConstants.ClientAppApi.Transactions)
        {
            TransactionViewFilter = transactionViewFilter;
        }

        public override async Task<IEnumerable<TransactionExtDto>> GetItems()
        {
            Log.Debug($"TransactionDataManager GetItems");
            using (var response = await HttpClient.GetAsync($"{EndPoint}?dateFrom={TransactionViewFilter.DateFrom.ToString("yyyy-MM-dd")}&dateTo={TransactionViewFilter.DateTo.ToString("yyyy-MM-dd")}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<IEnumerable<TransactionExtDto>>();
                return result;
            }
        }

        
    }
}