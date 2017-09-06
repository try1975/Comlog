using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CurEx.WebApi.Helpers
{
    public class DateTimeParameterAttribute : ParameterBindingAttribute
    {
        public string DateFormat { get; set; }

        private bool ReadFromQueryString { get; set; }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter.ParameterType != typeof(DateTime?)) return parameter.BindAsError("Expected type DateTime?");
            var binding = new DateTimeParameterBinding(parameter)
            {
                DateFormat = DateFormat,
                ReadFromQueryString = ReadFromQueryString
            };
            return binding;
        }
    }
}