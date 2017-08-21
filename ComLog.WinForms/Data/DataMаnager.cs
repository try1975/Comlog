using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ComLog.Common;
using ComLog.Dto;
using ComLog.WinForms.Interfaces.Data;

namespace ComLog.WinForms.Data
{
    public class DataMаnager : IDataMаnager
    {
        private readonly string _apiBanks;
        private readonly string _apiCurrencies;
        private readonly string _apiTransactions;
        private readonly HttpClient _walletHttpClient;

        public DataMаnager()
        {
            #region Endpoints

            var baseApi = ConfigurationManager.AppSettings["BaseApi"];
            var token = ConfigurationManager.AppSettings["ExternalToken"];
            _apiBanks = $"{baseApi}{ComLogConstants.ClientAppApi.Banks}/";
            _apiCurrencies = $"{baseApi}{ComLogConstants.ClientAppApi.Currencies}/";
            _apiTransactions = $"{baseApi}{ComLogConstants.ClientAppApi.Transactions}/";

            #endregion

            _walletHttpClient = new HttpClient(new LoggingHandler());
            _walletHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
        }

        #region Currencies

        public async Task<IEnumerable<CurrencyDto>> GetCurrencies()
        {
            using (var response = await _walletHttpClient.GetAsync($"{_apiCurrencies}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<List<CurrencyDto>>();
                return result;
            }
        }

        #endregion //Currencies


        #region Banks

        public async Task<IEnumerable<BankDto>> GetBanks()
        {
            using (var response = await _walletHttpClient.GetAsync($"{_apiBanks}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<List<BankDto>>();
                return result.OrderBy(d => d.Name).ToList();
            }
        }

        public async Task<BankDto> GetBank(Guid id)
        {
            using (var response = await _walletHttpClient.GetAsync($"{_apiBanks}{id}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<BankDto>();
                return result;
            }
        }

        public async Task<BankDto> PostBank(BankDto item)
        {
            using (var response = await _walletHttpClient.PostAsJsonAsync($"{_apiBanks}", item))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<BankDto>();
                return result;
            }
        }

        public async Task<BankDto> PutBank(BankDto item)
        {
            using (var response = await _walletHttpClient.PutAsJsonAsync($"{_apiBanks}", item))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<BankDto>();
                return result;
            }
        }

        public async Task<bool> DeleteBank(Guid id)
        {
            using (var response = await _walletHttpClient.DeleteAsync($"{_apiBanks}{id}"))
            {
                return response.IsSuccessStatusCode;
            }
        }

        #endregion //Banks

        #region Transactions
        public async Task<TransactionDto> PostTransaction(TransactionDto item)
        {
            using (var response = await _walletHttpClient.PostAsJsonAsync($"{_apiTransactions}", item))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<TransactionDto>();
                return result;
            }
        }
        #endregion //Transactions
    }
}