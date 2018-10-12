using CurEx.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurEx.Console
{
    internal static class Program
    {
        private static HttpClient HttpClient { get; set; }
        private static Dictionary<string, string> _finamCurrencies;

        private static void Main()
        {
            HttpClient = new HttpClient(new LoggingHandler());
            _finamCurrencies = JsonConvert.DeserializeObject<Dictionary<string, string>>(ConfigurationManager.AppSettings["FinamCurrencies"]);

            var pairs = GetCurrencyPairs().Result;
            foreach (var pair in pairs)
            {
                var txt = GetFinamRates(pair.Id).Result;
                if (string.IsNullOrEmpty(txt)) continue;
                var rates = txt.Split('\n');
                foreach (var rate in rates)
                {
                    if (string.IsNullOrEmpty(rate)) continue;
                    var rateFields = rate.Split(',');
                    var currencyPairRateDto = new CurrencyPairRateDto
                    {
                        CurrencyPairId = pair.Id,
                        RateDate = DateTime.ParseExact(rateFields[0], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None),
                        OpenRate = decimal.Parse(rateFields[2], NumberStyles.Currency, CultureInfo.InvariantCulture),
                        CloseRate =
                            decimal.Parse(rateFields[5], NumberStyles.Currency, CultureInfo.InvariantCulture),
                        HighRate = decimal.Parse(rateFields[3], NumberStyles.Currency, CultureInfo.InvariantCulture),
                        LowRate = decimal.Parse(rateFields[4], NumberStyles.Currency, CultureInfo.InvariantCulture),
                        // TODO: set rate equal to close rate - field 5
                        Rate = decimal.Parse(rateFields[2], NumberStyles.Currency, CultureInfo.InvariantCulture)
                    };
                    var dto =
                        GetCurrencyPairRateByDate(currencyPairRateDto.CurrencyPairId,
                            currencyPairRateDto.RateDate.ToString("yyyy-MM-dd")).Result;
                    if (dto != null) continue;
                    dto = PostCurrencyPairRate(currencyPairRateDto).Result;
                    if (dto == null) continue;
                    System.Console.WriteLine(
                        $"{dto.CurrencyPairId} {dto.RateDate:yyyy-MM-dd} {dto.Rate}");
                }
            }
            System.Console.WriteLine("Complete.");
            Thread.Sleep(3000);
        }

        private static async Task<string> GetFinamRates(string instruments)
        {
            var refreshValueCount = ConfigurationManager.AppSettings["RefreshValueCount"];
            if (string.IsNullOrEmpty(refreshValueCount)) refreshValueCount = "10";
            var endDate = DateTime.Today.AddDays(-1);
            var strEndDate01 = endDate.ToString("yyMMdd");
            var strEndDate02 = endDate.ToString("dd.MM.yyyy");
            var startDate = endDate.AddDays(-1 * int.Parse(refreshValueCount));
            var strStartDate01 = startDate.ToString("yyMMdd");
            var strStartDate02 = startDate.ToString("dd.MM.yyyy");
            var filename = $"{instruments}_{strStartDate01}_{strEndDate01}";
            var period = $"df={startDate.Day}&mf={startDate.Month - 1}&yf={startDate.Year}&from={strStartDate02}&dt={endDate.Day}&mt={endDate.Month - 1}&yt={endDate.Year}&to={strEndDate02}";
            if (!_finamCurrencies.TryGetValue(instruments, out var em)) return string.Empty;
            using (
                var response =
                    await
                        HttpClient.GetAsync(
                            $"http://export.finam.ru/{filename}.csv?market=5&em={em}&code={instruments}&apply=0&{period}&p=8&f={filename}&e=.csv&cn={instruments}&dtf=1&tmf=1&MSOR=1&mstimever=1&sep=1&sep2=1&datf=5")
                )
            {
                if (!response.IsSuccessStatusCode) return null;
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        private static async Task<CurrencyPairRateDto> GetCurrencyPairRateByDate(string currencyPairId, string rateDate)
        {
            using (
                var response =
                    await
                        HttpClient.GetAsync(
                            $"{ConfigurationManager.AppSettings["BaseApi"]}api/CurrencyPairRates?currencyPairId={currencyPairId}&rateDate={rateDate}")
                )
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<CurrencyPairRateDto>();
                return result;
            }
        }

        private static async Task<CurrencyPairRateDto> PostCurrencyPairRate(CurrencyPairRateDto dto)
        {
            using (var response = await HttpClient.PostAsJsonAsync($"{ConfigurationManager.AppSettings["BaseApi"]}api/CurrencyPairRates", dto))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<CurrencyPairRateDto>();
                return result;
            }
        }

        private static async Task<IEnumerable<CurrencyPairDto>> GetCurrencyPairs()
        {
            using (var response = await HttpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseApi"]}api/CurrencyPairs"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<List<CurrencyPairDto>>();
                return result;
            }
        }
    }
}