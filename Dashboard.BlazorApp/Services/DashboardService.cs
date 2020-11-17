using System.Linq;
using System.Threading.Tasks;
using Dashboard.Integration.Dto.Sbanken;

namespace Dashboard.BlazorApp.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ISbankenApiService _sbankenApiService;
        private readonly ICoinbaseApiService _coinbaseApiService;

        public DashboardService(ISbankenApiService sbankenApiService, ICoinbaseApiService coinbaseApiService)
        {
            _sbankenApiService = sbankenApiService;
            _coinbaseApiService = coinbaseApiService;
        }
        
        public async Task<ViewModels.Sbanken.SbankenAccountsViewModel> GetSbankenSavingsSummary()
        {
            var accountsViewModel = await _sbankenApiService.GetSavingsAccounts();

            if (!accountsViewModel.Success)
            {
                return accountsViewModel;
            }

            var savingSummary = new SbankenAccountDto
            {
                Name = "Sbanken Sparing",
                Balance = accountsViewModel.SbankenAccounts.Sum(x => x.Balance),
                LastMonthBalance = accountsViewModel.SbankenAccounts.Sum(x => x.LastMonthBalance),
                LastYearBalance = accountsViewModel.SbankenAccounts.Sum(x => x.LastYearBalance)
            };
            
            accountsViewModel.SbankenAccounts.Clear();
            accountsViewModel.SbankenAccounts.Add(savingSummary);

            return accountsViewModel;
        }
        
        public async Task<ViewModels.Coinbase.CoinbaseAccountsViewModel> GetCoinbaseTotal()
        {
            var accountsViewModel = await _coinbaseApiService.GetAccounts();

            if (!accountsViewModel.Success)
            {
                return accountsViewModel;
            }

            var total = accountsViewModel.CoinbaseAccounts.First(x => x.Name == "Total");
            total.Name = "Coinbase";
            accountsViewModel.CoinbaseAccounts.Clear();
            accountsViewModel.CoinbaseAccounts.Add(total);

            return accountsViewModel;
        }
    }
}