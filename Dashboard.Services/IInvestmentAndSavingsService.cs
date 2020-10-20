using System.Threading.Tasks;
using Dashboard.ViewModels.Sbanken;

namespace Dashboard.Services
{
    public interface IInvestmentAndSavingsService
    {
        Task<ViewModels.Coinbase.AccountsViewModel> GetCoinbaseTotal();
        Task<TransactionSummariesViewModel> GetMikrosparTransactions();
        Task<InvestmentsViewModel> GetInvestments();
        Task<ViewModels.Sbanken.AccountsViewModel> GetSavingsAccounts();
    }
}