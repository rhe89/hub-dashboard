using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Dto.Sbanken;
using Dashboard.Integration;
using Dashboard.ViewModels.Sbanken;
using Hub.Web.Http;
using Hub.Web.ViewModels;

namespace Dashboard.Services
{
    public class SbankenApiService : ISbankenApiService
    {
        private readonly ISbankenApiConnector _sbankenApiConnector;

        public SbankenApiService(ISbankenApiConnector sbankenApiConnector)
        {
            _sbankenApiConnector = sbankenApiConnector;
        }

        public async Task<TransactionsViewModel> GetTransactions(int ageInDays)
        {
            var response = await _sbankenApiConnector.GetTransactions(ageInDays);

            if (!response.Success)
            {
                return ViewModelMappings.GetErrorViewModel<TransactionsViewModel, TransactionDto[]>(response);
            }

            return new TransactionsViewModel
            {
                Success = true,
                Transactions = response.Data
            };
        }

        public async Task<AccountsViewModel> GetStandardAccounts()
        {
            var response = await _sbankenApiConnector.GetStandardAccounts();

            return GetAccountsViewModel(response);
        }
        
        public async Task<AccountsViewModel> GetCreditAccounts()
        {
            var response = await _sbankenApiConnector.GetCreditAccounts();

            return GetAccountsViewModel(response);
        }
        
        public async Task<AccountsViewModel> GetSavingsAccounts()
        {
            var response = await _sbankenApiConnector.GetSavingsAccounts();

            return GetAccountsViewModel(response);
        }

        private static AccountsViewModel GetAccountsViewModel(Response<IList<AccountDto>> response)
        {
            if (!response.Success)
            {
                return ViewModelMappings.GetErrorViewModel<AccountsViewModel, IList<AccountDto>>(response);
            }

            return new AccountsViewModel
            {
                Success = true,
                Accounts = response.Data
            };
        }

        public async Task<TransactionSummariesViewModel> GetMikrosparTransactions()
        {
            var response = await _sbankenApiConnector.GetMikrosparTransactions();

            if (!response.Success)
            {
                return ViewModelMappings.GetErrorViewModel<TransactionSummariesViewModel, TransactionSummaryDto>(
                    response);
            }

            return new TransactionSummariesViewModel
            {
                Success = true,
                TransactionSummary = response.Data
            };
        }
        
        public async Task<TransactionSummariesViewModel> GetInvestmentTransactions()
        {
            var response = await _sbankenApiConnector.GetInvestmentTransactions();

            if (!response.Success)
            {
                return ViewModelMappings.GetErrorViewModel<TransactionSummariesViewModel, TransactionSummaryDto>(
                    response);
            }

            return new TransactionSummariesViewModel
            {
                Success = true,
                TransactionSummary = response.Data
            };
        }
    }
}