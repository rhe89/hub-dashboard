using Dashboard.Integration;

namespace Dashboard.Services
{
    public class SpreadsheetApiService : ISpreadsheetApiService
    {
        public SpreadsheetApiService(ISpreadsheetApiConnector hubApiConnector)
        {
        }
    }
}