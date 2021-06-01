using CurEx.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
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
        private static readonly string BaseApiInternal = ConfigurationManager.AppSettings["BaseApi"];

        private static async Task Main()
        {
            _httpClient = new HttpClient(new LoggingHandler());
            _finamCurrencies = JsonConvert.DeserializeObject<Dictionary<string, string>>(ConfigurationManager.AppSettings["FinamCurrencies"]);
            //foreach (var finamCurrency in _finamCurrencies)
            //{
            //    System.Console.WriteLine($"finamCurrency {finamCurrency.Key}={finamCurrency.Value}");
            //}
            var culture = CultureInfo.InvariantCulture;
            var listPair = await GetCurrencyPairs();
            foreach (var pair in listPair)
            {
                var txt = await GetFinamRates(pair.Id);
                if (string.IsNullOrEmpty(txt)) continue;
                var rates = txt.Split('\n');
                Thread.Sleep(2000);
                foreach (var rate in rates)
                {

                    if (string.IsNullOrEmpty(rate)) continue;

                    try
                    {
                        var rateFields = rate.Split(',');
                        var currencyPairRateDto = new CurrencyPairRateDto
                        {
                            CurrencyPairId = pair.Id,
                            RateDate = DateTime.ParseExact(rateFields[0], "yyyyMMdd", culture, DateTimeStyles.None),
                            OpenRate = decimal.Parse(rateFields[2], NumberStyles.Currency, culture),
                            CloseRate = decimal.Parse(rateFields[5], NumberStyles.Currency, culture),
                            HighRate = decimal.Parse(rateFields[3], NumberStyles.Currency, culture),
                            LowRate = decimal.Parse(rateFields[4], NumberStyles.Currency, culture),
                        };
                        currencyPairRateDto.Rate = currencyPairRateDto.OpenRate.Value;

                        var dto = await GetCurrencyPairRateByDate(currencyPairRateDto.CurrencyPairId, $"{currencyPairRateDto.RateDate:yyyy-MM-dd}");
                        const decimal diff = 0.0001m;
                        var isContinue = dto != null;
                        //if (isContinue && dto.OpenRate.HasValue)
                        //    isContinue = Math.Abs(dto.OpenRate.Value - currencyPairRateDto.OpenRate.Value) < diff;
                        //if (isContinue && dto.CloseRate.HasValue)
                        //    isContinue = Math.Abs(dto.CloseRate.Value - currencyPairRateDto.CloseRate.Value) < diff;
                        if (isContinue && dto.HighRate.HasValue)
                            isContinue = Math.Abs(dto.HighRate.Value - currencyPairRateDto.HighRate.Value) < diff;
                        if (isContinue && dto.LowRate.HasValue)
                            isContinue = Math.Abs(dto.LowRate.Value - currencyPairRateDto.LowRate.Value) < diff;
                        if (isContinue) continue;

                        CurrencyPairRateDto changedDto;
                        if (dto != null)
                        {
                            currencyPairRateDto.Id = dto.Id;
                            currencyPairRateDto.OpenRate = dto.OpenRate;
                            currencyPairRateDto.CloseRate = dto.CloseRate;
                            changedDto = await PutCurrencyPairRate(currencyPairRateDto);
                        }
                        else changedDto = await PostCurrencyPairRate(currencyPairRateDto);
                        if (changedDto == null) continue;
                        System.Console.WriteLine($"{changedDto.CurrencyPairId} {changedDto.RateDate:yyyy-MM-dd} {changedDto.Rate}");
                    }
                    catch
                    {
                        System.Console.WriteLine($"Error parse response {pair.Id}");
                    }
                }
            }

            foreach (var pair in listPair)
            {
                var convertFrom = pair.Id.Substring(0, 3);
                var convertTo = pair.Id.Substring(3);
                CheckFromRatesApi(convertFrom, convertTo);
            }
            CheckFromCurrencyMe("AED", "USD");



            System.Console.WriteLine("Complete.");
            Thread.Sleep(3000);
        }

        private static async Task<string> GetFinamRates(string instruments)
        {

            var refreshValueCount = ConfigurationManager.AppSettings["RefreshValueCount"];
            if (string.IsNullOrEmpty(refreshValueCount)) refreshValueCount = "10";

            //var endDate = DateTime.Today.AddDays(-1);
            var endDate = DateTime.Today;
            var startDate = endDate.AddDays(-1 * int.Parse(refreshValueCount));
            var filename = $"{instruments}_{startDate:yyMMdd}_{endDate:yyMMdd}";

            var period = $"df={startDate.Day}&mf={startDate.Month - 1}&yf={startDate.Year}&from={startDate:dd.MM.yyyy}&dt={endDate.Day}&mt={endDate.Month - 1}&yt={endDate.Year}&to={endDate:dd.MM.yyyy}";
            if (!_finamCurrencies.TryGetValue(instruments, out var em)) return string.Empty;
            var requestUri = $"http://export.finam.ru/{filename}.csv?market=5&em={em}&code={instruments}&apply=0&{period}&p=8&f={filename}&e=.csv&cn={instruments}&dtf=1&tmf=1&MSOR=1&mstimever=1&sep=1&sep2=1&datf=5";
            using (var response = await _httpClient.GetAsync(requestUri))
            {
                if (!response.IsSuccessStatusCode) return null;
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
        }

        private static async Task<CurrencyPairRateDto> GetCurrencyPairRateByDate(string currencyPairId, string rateDate)
        {
            using (var response = await _httpClient.GetAsync($"{BaseApiInternal}api/CurrencyPairRates?currencyPairId={currencyPairId}&rateDate={rateDate}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<CurrencyPairRateDto>();
                return result;
            }
        }

        private static async Task<CurrencyPairRateDto> PostCurrencyPairRate(CurrencyPairRateDto dto)
        {
            using (var response = await _httpClient.PostAsJsonAsync($"{BaseApiInternal}api/CurrencyPairRates", dto))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<CurrencyPairRateDto>();
                return result;
            }
        }
        private static async Task<CurrencyPairRateDto> PutCurrencyPairRate(CurrencyPairRateDto dto)
        {
            using (var response = await _httpClient.PutAsJsonAsync($"{BaseApiInternal}api/CurrencyPairRates", dto))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<CurrencyPairRateDto>();
                return result;
            }
        }

        private static async Task<List<CurrencyPairDto>> GetCurrencyPairs()
        {
            using (var response = await _httpClient.GetAsync($"{BaseApiInternal}api/CurrencyPairs"))
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
            if (!decimal.TryParse(getRate, NumberStyles.Any, new CultureInfo("en-US"), out var rate)) return;
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


        private static void CheckFromRatesApi(string convertFrom, string convertTo)
        {
            for (int i = 12 - 1; i >= 0; i--)
            {
                var date = DateTime.Today.AddDays(-i);
                if (GetCurrencyPairRateByDate($"{convertFrom}{convertTo}", $"{date:yyyy-MM-dd}").Result != null) continue;
                var getRate = GetRatesApiDateRate(convertFrom, $"{date:yyyy-MM-dd}").Result;
                if (string.IsNullOrEmpty(getRate)) continue;
                var ratesApiDto = JsonConvert.DeserializeObject<RatesApiDto>(getRate);
                if (ratesApiDto == null) continue;
                var rate = ratesApiDto.GetRate(convertTo);
                if (rate == 0) continue;
                var currencyPairRateDto = new CurrencyPairRateDto
                {
                    RateDate = date,
                    CurrencyPairId = $"{convertFrom}{convertTo}",
                    Rate = rate,
                    OpenRate = rate,
                    CloseRate = rate,
                    LowRate = rate * 0.992m,
                    HighRate = rate * 1.008m
                };
                var dto = PostCurrencyPairRate(currencyPairRateDto).Result;
                if (dto == null) return;
                System.Console.WriteLine($"{dto.CurrencyPairId} {dto.RateDate:yyyy-MM-dd} {dto.Rate}");
            }

        }

        //https://exchangeratesapi.io/documentation/
        private static async Task<string> GetRatesApiLatestRate(string convertFrom)
        {
            using (var response = await _httpClient.GetAsync($"http://api.exchangeratesapi.io/v1/latest?access_key=31bd69d9567d159d57b8383ad608dbad&base={convertFrom}"))
            {
                if (!response.IsSuccessStatusCode) return null;
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream, Encoding.UTF8)) return reader.ReadToEnd();
                }
            }
        }

        private static async Task<string> GetRatesApiDateRate(string convertFrom, string date)
        {
            using (var response = await _httpClient.GetAsync($"http://api.exchangeratesapi.io/v1/{date}?base={convertFrom}&access_key=31bd69d9567d159d57b8383ad608dbad"))
            {
                if (!response.IsSuccessStatusCode) return null;
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream, Encoding.UTF8)) return reader.ReadToEnd();
                }
            }
        }
    }
}