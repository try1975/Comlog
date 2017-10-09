﻿using System.Collections.Generic;
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
        public IAccountViewFilter AccountViewFilter { get; set; }

        public AccountDataManager(IAccountViewFilter accountViewFilter) : base(ComLogConstants.ClientAppApi.Accounts)
        {
            AccountViewFilter = accountViewFilter;
        }

        public override async Task<IEnumerable<AccountExtDto>> GetItems()
        {
            using (var response = await HttpClient.GetAsync($"{EndPoint}?withBalance=true"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<IEnumerable<AccountExtDto>>();
                if (!AccountViewFilter.ShowClosed) result = result.Where(z => z.Closed == null);
                return result;
            }
        }

       
    }
}