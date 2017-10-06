using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ComLog.Common;
using ComLog.Dto.Ext;
using ComLog.WinForms.Data.Common;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class AccountDataManager : TypedDataMаnager<AccountExtDto, int>, IAccountDataManager
    {
        public AccountDataManager() : base(ComLogConstants.ClientAppApi.Accounts)
        {
        }

        public override async Task<IEnumerable<AccountExtDto>> GetItems()
        {
            using (var response = await HttpClient.GetAsync($"{EndPoint}?ext=true"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<IEnumerable<AccountExtDto>>();
                return result;
            }
        }

    }
}