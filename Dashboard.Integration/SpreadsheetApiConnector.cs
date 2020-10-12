using System.Net.Http;
using Hub.Web.Http;
using Microsoft.Extensions.Logging;

namespace Dashboard.Integration
{
    public class SpreadsheetApiConnector : HttpClientService, ISpreadsheetApiConnector
    {
        public SpreadsheetApiConnector(HttpClient httpClient, ILogger<SpreadsheetApiConnector> logger) : base(httpClient, logger, "SpreadsheetApi") {}
    }
}