using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
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
           writer.WriteLine($"{Escape(dto.TransactionDate.ToString("dd/MM/yyyy"))},{Escape(dto.BankName)},{Escape(dto.AccountName)},{Escape(dto.TransactionTypeName)},{Escape(dto.CurrencyId)},{Escape(dto.Credits)},{Escape(dto.Debits)},{Escape(dto.Charges)},{Escape(dto.FromTo)},{Escape(dto.Description)},{Escape(dto.UsdCredits)},{Escape(dto.UsdDebits)},{Escape(dto.Report)},{Escape(dto.Dcc)},{Escape(dto.UsdDcc)}");
        }

        private static void WriteHeader(TextWriter writer)
        {
            writer.WriteLine($"{nameof(TransactionReport01Dto.TransactionDate)},{nameof(TransactionReport01Dto.BankName)},{nameof(TransactionReport01Dto.AccountName)},{nameof(TransactionReport01Dto.TransactionTypeName)},{nameof(TransactionReport01Dto.CurrencyId)},{nameof(TransactionReport01Dto.Credits)},{nameof(TransactionReport01Dto.Debits)},{nameof(TransactionReport01Dto.Charges)},{nameof(TransactionReport01Dto.FromTo)},{nameof(TransactionReport01Dto.Description)},{nameof(TransactionReport01Dto.UsdCredits)},{nameof(TransactionReport01Dto.UsdDebits)},{nameof(TransactionReport01Dto.Report)},{nameof(TransactionReport01Dto.Dcc)},{nameof(TransactionReport01Dto.UsdDcc)}");
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