using System.Threading.Tasks;
using Dashboard.BlazorApp.ViewModels.Sbanken;

namespace Dashboard.BlazorApp.Services
{
    public interface ISbankenApiService
    {
        Task<TransactionsViewModel> GetTransactions(int ageInDays);
        Task<SbankenAccountsViewModel> GetStandardAccounts();
        Task<SbankenAccountsViewModel> GetCreditAccounts();
        Task<SbankenAccountsViewModel> GetSavingsAccounts();
        Task<TransactionSummariesViewModel> GetMikrosparTransactions();
        Task<TransactionSummariesViewModel> GetInvestmentTransactions();
    }
}