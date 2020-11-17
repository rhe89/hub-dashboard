using System.Linq;
using System.Threading.Tasks;
using Dashboard.BlazorApp.ViewModels.Sbanken;

namespace Dashboard.BlazorApp.Services
{
    public class InvestmentAndSavingsService : IInvestmentAndSavingsService
    {
        private readonly ISbankenApiService _sbankenApiService;
        private readonly ICoinbaseApiService _coinbaseApiService;

        public InvestmentAndSavingsService(ISbankenApiService sbankenApiService, ICoinbaseApiService coinbaseApiService)
        {
            _sbankenApiService = sbankenApiService;
            _coinbaseApiService = coinbaseApiService;
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
        
        public async Task<TransactionSummariesViewModel> GetMikrosparTransactions()
        {
            return await _sbankenApiService.GetMikrosparTransactions();
        }
        
        public async Task<SbankenInvestmentsViewModel> GetInvestments()
        {
            var transactionsViewModel = await _sbankenApiService.GetInvestmentTransactions();

            return new SbankenInvestmentsViewModel
            {
                Value = 0,
                SbankenTransactionSummary = transactionsViewModel.SbankenTransactionSummary,
                ErrorMessage = transactionsViewModel.ErrorMessage,
                StatusCode = transactionsViewModel.StatusCode,
                Success = transactionsViewModel.Success
            };
        }

        public async Task<ViewModels.Sbanken.SbankenAccountsViewModel> GetSavingsAccounts()
        {
            return await _sbankenApiService.GetSavingsAccounts();
        }
    }
}