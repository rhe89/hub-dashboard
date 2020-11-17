using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.BlazorApp.ViewModels.Coinbase;
using Dashboard.Integration;
using Dashboard.Integration.Dto.Coinbase;
using Hub.Web.BlazorServer.ViewModels;

namespace Dashboard.BlazorApp.Services
{
    public class CoinbaseApiService : ICoinbaseApiService
    {
        private readonly ICoinbaseApiConnector _coinbaseApiConnector;

        public CoinbaseApiService(ICoinbaseApiConnector coinbaseApiConnector)
        {
            _coinbaseApiConnector = coinbaseApiConnector;
        }
        
        public async Task<CoinbaseAccountsViewModel> GetAccounts()
        {
            var response = await _coinbaseApiConnector.GetAccounts();

            if (!response.Success)
            {
                return ViewModelMappings.GetErrorViewModel<CoinbaseAccountsViewModel, IList<CoinbaseAccountDto>>(response);
            }

            return new CoinbaseAccountsViewModel
            {
                Success = true,
                CoinbaseAccounts = response.Data
            };
        }
    }
}