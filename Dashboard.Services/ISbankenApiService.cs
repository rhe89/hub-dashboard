using System.Threading.Tasks;
using Dashboard.ViewModels.Sbanken;

namespace Dashboard.Services
{
    public interface ISbankenApiService
    {
        Task<TransactionsViewModel> GetTransactions(int ageInDays);
        Task<AccountsViewModel> GetStandardAccounts();
        Task<AccountsViewModel> GetCreditAccounts();
        Task<AccountsViewModel> GetSavingsAccounts();
        Task<TransactionSummariesViewModel> GetMikrosparTransactions();
        Task<TransactionSummariesViewModel> GetInvestmentTransactions();
    }
}