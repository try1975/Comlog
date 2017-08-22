using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CurEx.Dto.Dto;

namespace CurEx.Console
{
    internal static class Program
    {
        private static HttpClient Fx { get; set; }

        private static void Main()
        {
            Fx = new HttpClient(new LoggingHandler());
            var pairs = GetCurrencyPairs().Result;
            foreach (var pair in pairs)
            {
                var txt = GetFxRates(pair.Id).Result;
                var rates = txt.Split('\n');
                foreach (var rate in rates)
                {
                    if (string.IsNullOrEmpty(rate)) continue;
                    var rateFields = rate.Split(',');
                    var currencyPairRateDto = new CurrencyPairRateDto
                    {
                        CurrencyPairId = pair.Id,
                        RateDate = DateTime.Parse(rateFields[1]),
                        OpenRate = decimal.Parse(rateFields[2], NumberStyles.Currency, CultureInfo.InvariantCulture),
                        CloseRate = decimal.Parse(rateFields[3], NumberStyles.Currency, CultureInfo.InvariantCulture),
                        HighRate = decimal.Parse(rateFields[4], NumberStyles.Currency, CultureInfo.InvariantCulture),
                        LowRate = decimal.Parse(rateFields[5], NumberStyles.Currency, CultureInfo.InvariantCulture),
                        Rate = decimal.Parse(rateFields[2], NumberStyles.Currency, CultureInfo.InvariantCulture)
                    };
                    var dto =
                        GetCurrencyPairRateByDate(currencyPairRateDto.CurrencyPairId,
                            currencyPairRateDto.RateDate.ToString("yyyy-MM-dd")).Result;
                    if (dto != null) continue;
                    dto = PostCurrencyPairRate(currencyPairRateDto).Result;
                    if (dto == null) continue;
                    System.Console.WriteLine($"{dto.CurrencyPairId} {dto.RateDate.ToString("yyyy-MM-dd")} {dto.Rate}");
                }
            }
            System.Console.ReadKey();
        }

        private static async Task<string> GetFxRates(string instruments)
        {
            using (
                var response =
                    await
                        Fx.GetAsync(
                            $"http://api.fxhistoricaldata.com/indicators?instruments={instruments}&expression=open,close,high,low&item_count=10&format=csv&timeframe=day")
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
                        Fx.GetAsync(
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
            using (var response = await Fx.PostAsJsonAsync($"{ConfigurationManager.AppSettings["BaseApi"]}api/CurrencyPairRates", dto))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<CurrencyPairRateDto>();
                return result;
            }
        }

        private static async Task<IEnumerable<CurrencyPairDto>> GetCurrencyPairs()
        {
            using (var response = await Fx.GetAsync($"{ConfigurationManager.AppSettings["BaseApi"]}api/CurrencyPairs"))
            {
                if (!response.IsSuccessStatusCode) return null;
                var result = await response.Content.ReadAsAsync<List<CurrencyPairDto>>();
                return result;
            }
        }
    }
}