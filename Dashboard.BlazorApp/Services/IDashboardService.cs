using System.Threading.Tasks;

namespace Dashboard.BlazorApp.Services
{
    public interface IDashboardService
    {
        Task<ViewModels.Coinbase.CoinbaseAccountsViewModel> GetCoinbaseTotal();
        Task<ViewModels.Sbanken.SbankenAccountsViewModel> GetSbankenSavingsSummary();
    }
}