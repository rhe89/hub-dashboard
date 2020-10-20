using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Dto.Coinbase;
using Dashboard.Integration;
using Dashboard.ViewModels.Coinbase;
using Hub.Web.ViewModels;

namespace Dashboard.Services
{
    public class CoinbaseApiService : ICoinbaseApiService
    {
        private readonly ICoinbaseApiConnector _coinbaseApiConnector;

        public CoinbaseApiService(ICoinbaseApiConnector coinbaseApiConnector)
        {
            _coinbaseApiConnector = coinbaseApiConnector;
        }
        
        public async Task<AccountsViewModel> GetAccounts()
        {
            var response = await _coinbaseApiConnector.GetAccounts();

            if (!response.Success)
            {
                return ViewModelMappings.GetErrorViewModel<AccountsViewModel, IList<AccountDto>>(response);
            }

            return new AccountsViewModel
            {
                Success = true,
                Accounts = response.Data
            };
        }
    }
}