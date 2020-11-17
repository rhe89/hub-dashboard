using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Integration.Dto.Coinbase;
using Hub.Web.Http;

namespace Dashboard.Integration
{
    public interface ICoinbaseApiConnector
    {
        Task<Response<IList<CoinbaseAccountDto>>> GetAccounts();
    }
}