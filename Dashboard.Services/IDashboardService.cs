using System.Threading.Tasks;

namespace Dashboard.Services
{
    public interface IDashboardService
    {
        Task<ViewModels.Coinbase.AccountsViewModel> GetCoinbaseTotal();
        Task<ViewModels.Sbanken.AccountsViewModel> GetSbankenSavingsSummary();
    }
}