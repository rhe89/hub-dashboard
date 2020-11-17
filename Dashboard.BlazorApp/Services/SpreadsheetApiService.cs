using Dashboard.Integration;

namespace Dashboard.BlazorApp.Services
{
    public class SpreadsheetApiService : ISpreadsheetApiService
    {
        public SpreadsheetApiService(ISpreadsheetApiConnector hubApiConnector)
        {
        }
    }
}