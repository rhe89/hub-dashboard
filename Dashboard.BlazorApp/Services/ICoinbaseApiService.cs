using System.Threading.Tasks;
using Dashboard.BlazorApp.ViewModels.Coinbase;

namespace Dashboard.BlazorApp.Services
{
    public interface ICoinbaseApiService
    {
        Task<CoinbaseAccountsViewModel> GetAccounts();
    }
}