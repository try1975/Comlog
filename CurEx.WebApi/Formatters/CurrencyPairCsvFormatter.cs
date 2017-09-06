using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using CurEx.Dto.Dto;

namespace CurEx.WebApi.Formatters
{
    public class CurrencyPairCsvFormatter: BufferedMediaTypeFormatter
    {
        public CurrencyPairCsvFormatter()
        {
            // Add the supported media type.
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == typeof(CurrencyPairRateDto))
            {
                return true;
            }
            var enumerableType = typeof(IEnumerable<CurrencyPairRateDto>);
            return enumerableType.IsAssignableFrom(type);
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.Add("Content-Disposition", $"attachment; filename = test_{DateTime.Now.ToString("yyyyMMddhhmmssfff")}.csv");
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                var dtos = value as IEnumerable<CurrencyPairRateDto>;
                if (dtos != null)
                {
                    foreach (var dto in dtos)
                    {
                        WriteItem(dto, writer);
                    }
                }
                else
                {
                    var dto = value as CurrencyPairRateDto;
                    if (dto == null)
                    {
                        throw new InvalidOperationException("Cannot serialize type");
                    }
                    WriteItem(dto, writer);
                }
            }
        }

        // Helper methods for serializing Products to CSV format. 
        private static void WriteItem(CurrencyPairRateDto dto, TextWriter writer)
        {
            writer.WriteLine($"{Escape(dto.CurrencyPairId)},{Escape(dto.RateDate.ToString("dd.MM.yyyy"))},{Escape(dto.OpenRate)},{Escape(dto.HighRate)},{Escape(dto.LowRate)},{Escape(dto.CloseRate)}");
        }

        private static readonly char[] SpecialChars = { ',', '\n', '\r', '"' };

        private static string Escape(object o)
        {
            if (o == null) return "";
            var field = o.ToString();
            return field.IndexOfAny(SpecialChars) != -1 ? $"\"{field.Replace("\"", "\"\"")}\"" : field;
        }
    }
}