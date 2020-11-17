using System.Collections.Generic;
using Dashboard.Integration.Dto.Coinbase;
using Hub.Web.BlazorServer.ViewModels;

namespace Dashboard.BlazorApp.ViewModels.Coinbase
{
    public class CoinbaseAccountsViewModel : ApiResponseViewModel
    {
        public IList<CoinbaseAccountDto> CoinbaseAccounts { get; set; }
    }
}