using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ComLog.Dto;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms.Data.Common
{
    public abstract class TypedDataM�nager<T, TK> : ITypedDataM�nager<T, TK> where T : class, IDto<TK>
    {
        protected readonly string _endPoint;
        protected readonly HttpClient _httpClient;

        protected TypedDataM�nager(string endPoint)
        {
            var baseApi = ConfigurationManager.AppSettings["BaseApi"];
            var token = ConfigurationManager.AppSettings["ExternalToken"];
            _endPoint = $"{baseApi}{endPoint}/";

            _httpClient = new HttpClient(new LoggingHandler());
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
        }

        public virtual async Task<IEnumerable<T>> GetItems()
        {
            using (var response = await _httpClient.GetAsync($"{_endPoint}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<IEnumerable<T>>();
                //#if DEBUG
                //using (var stream = await response.Content.ReadAsStreamAsync())
                //{
                //    stream.Position = 0;
                //    using (var reader = new StreamReader(stream, Encoding.UTF8))
                //    {
                //        Debug.WriteLine(reader.ReadToEnd());
                //    }
                //}
                //#endif
                return result;
            }
        }

        public async Task<T> GetItem(TK id)
        {
            using (var response = await _httpClient.GetAsync($"{_endPoint}{id}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<T>();
                return result;
            }
        }

        public async Task<T> PostItem(T item)
        {
            using (var response = await _httpClient.PostAsJsonAsync($"{_endPoint}", item))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<T>();
                return result;
            }
        }

        public async Task<T> PutItem(T item)
        {
            using (var response = await _httpClient.PutAsJsonAsync($"{_endPoint}", item))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<T>();
                return result;
            }
        }

        public async Task<bool> DeleteItem(TK id)
        {
            using (var response = await _httpClient.DeleteAsync($"{_endPoint}{id}"))
            {
                return response.IsSuccessStatusCode;
            }
        }
    }
}