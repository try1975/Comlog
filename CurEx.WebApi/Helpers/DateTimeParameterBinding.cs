using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace CurEx.WebApi.Helpers
{
    public class DateTimeParameterBinding : HttpParameterBinding
    {
        public string DateFormat { get; set; }

        public bool ReadFromQueryString { get; set; }


        public DateTimeParameterBinding(HttpParameterDescriptor descriptor): base(descriptor) { }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,HttpActionContext actionContext,CancellationToken cancellationToken)
        {
            string dateToParse = null;
            var paramName = Descriptor.ParameterName;

            if (ReadFromQueryString)
            {
                // reading from query string
                var nameVal = actionContext.Request.GetQueryNameValuePairs();
                dateToParse = nameVal.FirstOrDefault(q => q.Key.Equals(paramName, StringComparison.OrdinalIgnoreCase)).Value;
            }
            else
            {
                // reading from route
                var routeData = actionContext.Request.GetRouteData();
                object dateObj;
                if (routeData.Values.TryGetValue(paramName, out dateObj))
                {
                    dateToParse = Convert.ToString(dateObj);
                }
            }

            DateTime? dateTime = null;
            if (!string.IsNullOrEmpty(dateToParse))
            {
                dateTime = string.IsNullOrEmpty(DateFormat) ? ParseDateTime(dateToParse) : ParseDateTime(dateToParse, new[] { DateFormat });
            }

            SetValue(actionContext, dateTime);

            return Task.FromResult<object>(null);
        }

        private static DateTime? ParseDateTime(
            string dateToParse,
            string[] formats = null,
            IFormatProvider provider = null,
            DateTimeStyles styles = DateTimeStyles.AssumeLocal)
        {
            var customDateFormats = new[]
                {
                    "yyyyMMddTHHmmssZ",
                    "yyyyMMddTHHmmZ",
                    "yyyyMMddTHHmmss",
                    "yyyyMMddTHHmm",
                    "yyyyMMddHHmmss",
                    "yyyyMMddHHmm",
                    "yyyyMMdd",
                    "yyyy-MM-dd-HH-mm-ss",
                    "yyyy-MM-dd-HH-mm",
                    "yyyy-MM-dd",
                    "MM-dd-yyyy"
                };

            if (formats == null)
            {
                formats = customDateFormats;
            }

            foreach (var format in formats)
            {
                DateTime validDate;
                if (format.EndsWith("Z"))
                {
                    if (DateTime.TryParseExact(dateToParse, format,
                             provider,
                             DateTimeStyles.AssumeUniversal,
                             out validDate))
                    {
                        return validDate;
                    }
                }
                else
                {
                    if (DateTime.TryParseExact(dateToParse, format,
                             provider, styles, out validDate))
                    {
                        return validDate;
                    }
                }
            }

            return null;
        }
    }
}