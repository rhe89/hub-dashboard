using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dashboard.Dto.Coinbase;
using Hub.Web.Http;
using Microsoft.Extensions.Logging;

namespace Dashboard.Integration
{
    public class CoinbaseApiConnector : HttpClientService, ICoinbaseApiConnector
    {
        private const string AccountsPath = "/api/account/accounts";
        
        public CoinbaseApiConnector(HttpClient httpClient, ILogger<CoinbaseApiConnector> logger) : base(httpClient, logger, "CoinbaseApi") {}
        
        public async Task<Response<IList<AccountDto>>> GetAccounts()
        {
            return await Get<IList<AccountDto>>(AccountsPath);
        }
    }
}