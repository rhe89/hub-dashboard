using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dashboard.Integration.Dto.Coinbase;
using Hub.Web.Http;
using Microsoft.Extensions.Logging;

namespace Dashboard.Integration
{
    public class CoinbaseApiConnector : HttpClientService, ICoinbaseApiConnector
    {
        private const string AccountsPath = "/api/account/accounts";
        
        public CoinbaseApiConnector(HttpClient httpClient) : base(httpClient, "CoinbaseApi") {}
        
        public async Task<Response<IList<CoinbaseAccountDto>>> GetAccounts()
        {
            return await Get<IList<CoinbaseAccountDto>>(AccountsPath);
        }
    }
}