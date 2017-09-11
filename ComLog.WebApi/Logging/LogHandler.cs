using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace ComLog.WebApi.Logging
{
    public class LogHandler : DelegatingHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // log request body
            var requestBody = await request.Content.ReadAsStringAsync();
            Log.Debug(requestBody);
            //Trace.WriteLine(requestBody);

            // let other handlers process the request
            var result = await base.SendAsync(request, cancellationToken);

            if (result.Content == null) return result;
            // once response body is ready, log it
            var responseBody = await result.Content.ReadAsStringAsync();
            Log.Debug(responseBody);
            //Trace.WriteLine(responseBody);

            return result;
        }
    }
}