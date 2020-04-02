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
        private static HttpClient _httpClient { get; set; }
        private static Dictionary<string, string> _finamCurrencies;

        private static void Main()
        {
            _httpClient = new HttpClient(new LoggingHandler());
            _finamCurrencies = JsonConvert.DeserializeObject<Dictionary<string, string>>(ConfigurationManager.AppSettings["FinamCurrencies"]);
            //foreach (var finamCurrency in _finamCurrencies)
            //{
            //    System.Console.WriteLine($"finamCurrency {finamCurrency.Key}={finamCurrency.Value}");
            //}

            var pairs = GetCurrencyPairs().Result;
            foreach (var pair in pairs)
            {
                var txt = GetFinamRates(pair.Id).Result;
                if (string.IsNullOrEmpty(txt)) continue;
                var rates = txt.Split('\n');
                Thread.Sleep(2000);
                foreach (var rate in rates)
                {
                    if (string.IsNullOrEmpty(rate)) continue;
                    var rateFields = rate.Split(',');
                    var currencyPairRateDto = new CurrencyPairRateDto
                    {
                        CurrencyPairId = pair.Id,
                        RateDate = DateTime.ParseExact(rateFields[0], "yyyyMMdd", CultureInfo.InvariantCulture,
                            DateTimeStyles.None),
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
                    if (dto != null)
                    {
                        //System.Console.WriteLine(
                        //    $"From db:{dto.CurrencyPairId} {dto.RateDate:yyyy-MM-dd} {dto.Rate}");
                        continue;
                    }

                    dto = PostCurrencyPairRate(currencyPairRateDto).Result;
                    if (dto == null) continue;
                    System.Console.WriteLine(
                        $"{dto.CurrencyPairId} {dto.RateDate:yyyy-MM-dd} {dto.Rate}");
                }
            }

            //foreach (var pair in pairs)
            //{
            //    var convertFrom = pair.Id.Substring(0, 3);
            //    var convertTo = pair.Id.Substring(3);
            //    CheckFromCurrencyMe(convertFrom, convertTo);
            //}
            CheckFromCurrencyMe("AED", "USD");

            System.Console.WriteLine("Complete.");
            Thread.Sleep(3000);
        }

        private static async Task<string> GetFinamRates(string instruments)
        {
            var refreshValueCount = ConfigurationManager.AppSettings["RefreshValueCount"];
            if (string.IsNullOrEmpty(refreshValueCount)) refreshValueCount = "10";
            var endDate = DateTime.Today.AddDays(-1);
            //var strEndDate01 = endDate.ToString("yyMMdd");
            var strEndDate02 = endDate.ToString("dd.MM.yyyy");
            var startDate = endDate.AddDays(-1 * int.Parse(refreshValueCount));
            //var strStartDate01 = startDate.ToString("yyMMdd");
            var strStartDate02 = startDate.ToString("dd.MM.yyyy");
            var filename = $"{instruments}_{startDate:yyMMdd}_{endDate:yyMMdd}";
            var period = $"df={startDate.Day}&mf={startDate.Month - 1}&yf={startDate.Year}&from={strStartDate02}&dt={endDate.Day}&mt={endDate.Month - 1}&yt={endDate.Year}&to={strEndDate02}";
            if (!_finamCurrencies.TryGetValue(instruments, out var em)) return string.Empty;
            var formattableString = $"http://export.finam.ru/{filename}.csv?market=5&em={em}&code={instruments}&apply=0&{period}&p=8&f={filename}&e=.csv&cn={instruments}&dtf=1&tmf=1&MSOR=1&mstimever=1&sep=1&sep2=1&datf=5";
            using (var response = await _httpClient.GetAsync(formattableString))
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
            var formattableString = $"{ConfigurationManager.AppSettings["BaseApi"]}api/CurrencyPairRates?currencyPairId={currencyPairId}&rateDate={rateDate}";
            using (var response = await _httpClient.GetAsync(formattableString))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<CurrencyPairRateDto>();
                return result;
            }
        }

        private static async Task<CurrencyPairRateDto> PostCurrencyPairRate(CurrencyPairRateDto dto)
        {
            using (var response = await _httpClient.PostAsJsonAsync($"{ConfigurationManager.AppSettings["BaseApi"]}api/CurrencyPairRates", dto))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<CurrencyPairRateDto>();
                return result;
            }
        }

        private static async Task<IEnumerable<CurrencyPairDto>> GetCurrencyPairs()
        {
            using (var response = await _httpClient.GetAsync($"{ConfigurationManager.AppSettings["BaseApi"]}api/CurrencyPairs"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<List<CurrencyPairDto>>();
                return result;
            }
        }

        private static async Task<string> GetCurrencyMeRate(string convertFrom, string convertTo)
        {
            using (var response = await _httpClient.GetAsync($"https://www.currency.me.uk/remote/ER-CCCS2-AJAX.php?ConvertTo={convertTo}&ConvertFrom={convertFrom}&amount=1"))
            {
                if (!response.IsSuccessStatusCode) return null;
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream, Encoding.UTF8)) return reader.ReadToEnd();
                }
            }
        }

        private static void CheckFromCurrencyMe(string convertFrom, string convertTo)
        {
            var date = DateTime.Today;
            if (GetCurrencyPairRateByDate($"{convertFrom}{convertTo}", $"{date:yyyy-MM-dd}").Result != null) return;
            var getRate = GetCurrencyMeRate(convertFrom, convertTo).Result;
            if (string.IsNullOrEmpty(getRate)) return;
            if (!decimal.TryParse(getRate, NumberStyles.Any, new CultureInfo("en-US"), out decimal rate)) return;
            var currencyPairRateDto = new CurrencyPairRateDto
            {
                RateDate = date,
                CurrencyPairId = $"{convertFrom}{convertTo}",
                Rate = rate,
                OpenRate = rate,
                CloseRate = rate,
                LowRate = rate,
                HighRate = rate
            };
            var dto = PostCurrencyPairRate(currencyPairRateDto).Result;
            if (dto == null) return;
            System.Console.WriteLine($"{dto.CurrencyPairId} {dto.RateDate:yyyy-MM-dd} {dto.Rate}");
        }
    }
}