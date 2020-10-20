using System.Linq;
using System.Threading.Tasks;
using Dashboard.Dto.Sbanken;

namespace Dashboard.Services
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
        
        public async Task<ViewModels.Sbanken.AccountsViewModel> GetSbankenSavingsSummary()
        {
            var accountsViewModel = await _sbankenApiService.GetSavingsAccounts();

            if (!accountsViewModel.Success)
            {
                return accountsViewModel;
            }

            var savingSummary = new AccountDto
            {
                Name = "Sbanken Sparing",
                Balance = accountsViewModel.Accounts.Sum(x => x.Balance),
                LastMonthBalance = accountsViewModel.Accounts.Sum(x => x.LastMonthBalance),
                LastYearBalance = accountsViewModel.Accounts.Sum(x => x.LastYearBalance)
            };
            
            accountsViewModel.Accounts.Clear();
            accountsViewModel.Accounts.Add(savingSummary);

            return accountsViewModel;
        }
        
        public async Task<ViewModels.Coinbase.AccountsViewModel> GetCoinbaseTotal()
        {
            var accountsViewModel = await _coinbaseApiService.GetAccounts();

            if (!accountsViewModel.Success)
            {
                return accountsViewModel;
            }

            var total = accountsViewModel.Accounts.First(x => x.Name == "Total");
            total.Name = "Coinbase";
            accountsViewModel.Accounts.Clear();
            accountsViewModel.Accounts.Add(total);

            return accountsViewModel;
        }
    }
}