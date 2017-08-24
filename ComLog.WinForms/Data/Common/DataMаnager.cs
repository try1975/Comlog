using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ComLog.Common;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms.Data.Common
{
    public class DataMаnager : IDataMаnager
    {
        private readonly string _apiAccounts;
        private readonly string _apiAccountTypes;
        private readonly string _apiBanks;
        private readonly string _apiCurrencies;
        private readonly string _apiTransactionTypes;
        private readonly string _apiTransactions;
        private readonly HttpClient _comLogHttpClient;

        public DataMаnager()
        {
            #region Endpoints

            var baseApi = ConfigurationManager.AppSettings["BaseApi"];
            var token = ConfigurationManager.AppSettings["ExternalToken"];

            _apiAccounts = $"{baseApi}{ComLogConstants.ClientAppApi.Accounts}/";
            _apiAccountTypes = $"{baseApi}{ComLogConstants.ClientAppApi.AccountTypes}/";
            _apiBanks = $"{baseApi}{ComLogConstants.ClientAppApi.Banks}/";
            _apiCurrencies = $"{baseApi}{ComLogConstants.ClientAppApi.Currencies}/";
            _apiTransactionTypes = $"{baseApi}{ComLogConstants.ClientAppApi.TransactionTypes}/";
            _apiTransactions = $"{baseApi}{ComLogConstants.ClientAppApi.Transactions}/";

            #endregion

            _comLogHttpClient = new HttpClient(new LoggingHandler());
            _comLogHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
        }

        #region Accounts

        public async Task<IEnumerable<AccountExtDto>> GetAccounts()
        {
            using (var response = await _comLogHttpClient.GetAsync($"{_apiAccounts}?ext=true"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<List<AccountExtDto>>();
                return result.ToList();
            }
        }

        #endregion //Accounts


        #region Banks

        public async Task<IEnumerable<BankDto>> GetBanks()
        {
            using (var response = await _comLogHttpClient.GetAsync($"{_apiBanks}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<List<BankDto>>();
                return result.OrderBy(d => d.Name).ToList();
            }
        }

        public async Task<BankDto> GetBank(int id)
        {
            using (var response = await _comLogHttpClient.GetAsync($"{_apiBanks}{id}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<BankDto>();
                return result;
            }
        }

        public async Task<BankDto> PostBank(BankDto item)
        {
            using (var response = await _comLogHttpClient.PostAsJsonAsync($"{_apiBanks}", item))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<BankDto>();
                return result;
            }
        }

        public async Task<BankDto> PutBank(BankDto item)
        {
            using (var response = await _comLogHttpClient.PutAsJsonAsync($"{_apiBanks}", item))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<BankDto>();
                return result;
            }
        }

        public async Task<bool> DeleteBank(int id)
        {
            using (var response = await _comLogHttpClient.DeleteAsync($"{_apiBanks}{id}"))
            {
                return response.IsSuccessStatusCode;
            }
        }

        #endregion //Banks

        #region Currencies

        public async Task<IEnumerable<CurrencyDto>> GetCurrencies()
        {
            using (var response = await _comLogHttpClient.GetAsync($"{_apiCurrencies}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<List<CurrencyDto>>();
                return result;
            }
        }

        #endregion //Currencies

        #region Transactions
        public async Task<TransactionExtDto> PostTransaction(TransactionExtDto item)
        {
            using (var response = await _comLogHttpClient.PostAsJsonAsync($"{_apiTransactions}", item))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<TransactionExtDto>();
                return result;
            }
        }
        #endregion //Transactions

        #region TransactionTypes

        public async Task<IEnumerable<TransactionTypeDto>> GetTransactionTypes()
        {
            using (var response = await _comLogHttpClient.GetAsync($"{_apiTransactionTypes}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<List<TransactionTypeDto>>();
                return result;
            }
        }

        #endregion //TransactionTypes
    }
}