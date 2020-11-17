using System.Threading.Tasks;
using Dashboard.BlazorApp.ViewModels.Sbanken;

namespace Dashboard.BlazorApp.Services
{
    public interface IInvestmentAndSavingsService
    {
        Task<ViewModels.Coinbase.CoinbaseAccountsViewModel> GetCoinbaseTotal();
        Task<TransactionSummariesViewModel> GetMikrosparTransactions();
        Task<SbankenInvestmentsViewModel> GetInvestments();
        Task<ViewModels.Sbanken.SbankenAccountsViewModel> GetSavingsAccounts();
    }
}