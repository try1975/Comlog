using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using ComLog.Dto.Ext;

namespace ComLog.WebApi.Formaters
{
    public class TransactionReport01CsvFormatter : BufferedMediaTypeFormatter
    {
        public TransactionReport01CsvFormatter()
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
            if (type == typeof(TransactionReport01Dto))
            {
                return true;
            }
            var enumerableType = typeof(IEnumerable<TransactionReport01Dto>);
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
                var dtos = value as IEnumerable<TransactionReport01Dto>;
                WriteHeader(writer);
                if (dtos != null)
                {
                    foreach (var dto in dtos)
                    {
                        WriteItem(dto, writer);
                    }
                }
                else
                {
                    var dto = value as TransactionReport01Dto;
                    if (dto == null)
                    {
                        throw new InvalidOperationException("Cannot serialize type");
                    }
                    WriteItem(dto, writer);
                }
            }
        }

        // Helper methods for serializing Products to CSV format. 
        private static void WriteItem(TransactionReport01Dto dto, TextWriter writer)
        {
            var sb = new StringBuilder();
            sb.Append($"{Escape(dto.TransactionDate.ToString("dd/MM/yyyy"))}");
            sb.Append($",{Escape(dto.BankName)}");
            sb.Append($",{Escape(dto.AccountName)}");
            sb.Append($",{Escape(dto.TransactionTypeName)}");
            sb.Append($",{Escape(dto.CurrencyId)}");
            sb.Append($",{Escape(dto.Credits)}");
            sb.Append($",{Escape(dto.Debits)}");
            sb.Append($",{Escape(dto.Charges)}");
            sb.Append($",{Escape(dto.FromTo)}");
            sb.Append($",{Escape(dto.Description)}");
            var usdCredits = Escape($"{dto.UsdCredits:F2}");
            sb.Append($",{usdCredits}");
            sb.Append($",{Escape(dto.UsdDebits)}");
            sb.Append($",{Escape(dto.Report)}");
            sb.Append($",{Escape(dto.Dcc)}");
            var usdDcc = Escape($"{dto.UsdDcc:F2}");
            sb.Append($",{usdDcc}");
            var weekDt = dto.WeekDt ?? dto.TransactionDate;
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var weekNum = culture.Calendar.GetWeekOfYear(
                weekDt,
                System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday)
                .ToString()
                .Trim()
                .PadLeft(2, '0');

            sb.Append($",{Escape(weekDt.ToString("yyyy"))}-{weekNum}");

            writer.WriteLine(sb.ToString());
        }

        private static void WriteHeader(TextWriter writer)
        {
            var sb = new StringBuilder();
            sb.Append($"{nameof(TransactionReport01Dto.TransactionDate)}");
            sb.Append($",{nameof(TransactionReport01Dto.BankName)}");
            sb.Append($",{nameof(TransactionReport01Dto.AccountName)}");
            sb.Append($",{nameof(TransactionReport01Dto.TransactionTypeName)}");
            sb.Append($",{nameof(TransactionReport01Dto.CurrencyId)}");
            sb.Append($",{nameof(TransactionReport01Dto.Credits)}");
            sb.Append($",{nameof(TransactionReport01Dto.Debits)}");
            sb.Append($",{nameof(TransactionReport01Dto.Charges)}");
            sb.Append($",{nameof(TransactionReport01Dto.FromTo)}");
            sb.Append($",{nameof(TransactionReport01Dto.Description)}");
            sb.Append($",{nameof(TransactionReport01Dto.UsdCredits)}");
            sb.Append($",{nameof(TransactionReport01Dto.UsdDebits)}");
            sb.Append($",{nameof(TransactionReport01Dto.Report)}");
            sb.Append($",{nameof(TransactionReport01Dto.Dcc)}");
            sb.Append($",{nameof(TransactionReport01Dto.UsdDcc)}");
            sb.Append($",{nameof(TransactionReport01Dto.WeekDt)}");

            writer.WriteLine(sb.ToString());
        }

        private static readonly char[] SpecialChars = { ',', '\n', '\r', '"' };

        private static string Escape(object o)
        {
            if (o == null) return "";
            var field = o.ToString();
            field = Regex.Replace(field, @"\r\n?|\n|\r", "");
            return field.IndexOfAny(SpecialChars) != -1 ? $"\"{field.Replace("\"", "\"\"")}\"" : field;
        }
    }
}