using System.Linq;
using System.Threading.Tasks;
using Dashboard.ViewModels.Sbanken;

namespace Dashboard.Services
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
        
        public async Task<ViewModels.Coinbase.AccountsViewModel> GetCoinbaseTotal()
        {
            var accountsViewModel = await _coinbaseApiService.GetAccounts();

            if (!accountsViewModel.Success)
                return accountsViewModel;

            var total = accountsViewModel.Accounts.First(x => x.Name == "Total");
            
            total.Name = "Coinbase";
            accountsViewModel.Accounts.Clear();
            accountsViewModel.Accounts.Add(total);

            return accountsViewModel;
        }
        
        public async Task<TransactionSummariesViewModel> GetMikrosparTransactions()
        {
            return await _sbankenApiService.GetMikrosparTransactions();
        }
        
        public async Task<InvestmentsViewModel> GetInvestments()
        {
            var transactionsViewModel = await _sbankenApiService.GetInvestmentTransactions();

            return new InvestmentsViewModel
            {
                Value = 0,
                TransactionSummary = transactionsViewModel.TransactionSummary,
                ErrorMessage = transactionsViewModel.ErrorMessage,
                StatusCode = transactionsViewModel.StatusCode,
                Success = transactionsViewModel.Success
            };
        }

        public async Task<AccountsViewModel> GetSavingsAccounts()
        {
            return await _sbankenApiService.GetSavingsAccounts();
        }
    }

    public interface IInvestmentAndSavingsService
    {
        Task<ViewModels.Coinbase.AccountsViewModel> GetCoinbaseTotal();
        Task<TransactionSummariesViewModel> GetMikrosparTransactions();
        Task<InvestmentsViewModel> GetInvestments();
        Task<AccountsViewModel> GetSavingsAccounts();
    }
}