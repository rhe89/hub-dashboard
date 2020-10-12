using System.Threading.Tasks;
using Dashboard.ViewModels.Coinbase;

namespace Dashboard.Services
{
    public interface ICoinbaseApiService
    {
        Task<AccountsViewModel> GetAccounts();
    }
}