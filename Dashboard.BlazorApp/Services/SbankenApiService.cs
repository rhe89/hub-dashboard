using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.BlazorApp.ViewModels.Sbanken;
using Dashboard.Integration;
using Dashboard.Integration.Dto.Sbanken;
using Hub.Web.BlazorServer.ViewModels;
using Hub.Web.Http;

namespace Dashboard.BlazorApp.Services
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
                return ViewModelMappings.GetErrorViewModel<TransactionsViewModel, SbankenTransactionDto[]>(response);
            }

            return new TransactionsViewModel
            {
                Success = true,
                Transactions = response.Data
            };
        }

        public async Task<SbankenAccountsViewModel> GetStandardAccounts()
        {
            var response = await _sbankenApiConnector.GetStandardAccounts();

            return GetAccountsViewModel(response);
        }
        
        public async Task<SbankenAccountsViewModel> GetCreditAccounts()
        {
            var response = await _sbankenApiConnector.GetCreditAccounts();

            return GetAccountsViewModel(response);
        }
        
        public async Task<SbankenAccountsViewModel> GetSavingsAccounts()
        {
            var response = await _sbankenApiConnector.GetSavingsAccounts();

            return GetAccountsViewModel(response);
        }

        private static SbankenAccountsViewModel GetAccountsViewModel(Response<IList<SbankenAccountDto>> response)
        {
            if (!response.Success)
            {
                return ViewModelMappings.GetErrorViewModel<SbankenAccountsViewModel, IList<SbankenAccountDto>>(response);
            }

            return new SbankenAccountsViewModel
            {
                Success = true,
                SbankenAccounts = response.Data
            };
        }

        public async Task<TransactionSummariesViewModel> GetMikrosparTransactions()
        {
            var response = await _sbankenApiConnector.GetMikrosparTransactions();

            if (!response.Success)
            {
                return ViewModelMappings.GetErrorViewModel<TransactionSummariesViewModel, SbankenTransactionSummaryDto>(
                    response);
            }

            return new TransactionSummariesViewModel
            {
                Success = true,
                SbankenTransactionSummary = response.Data
            };
        }
        
        public async Task<TransactionSummariesViewModel> GetInvestmentTransactions()
        {
            var response = await _sbankenApiConnector.GetInvestmentTransactions();

            if (!response.Success)
            {
                return ViewModelMappings.GetErrorViewModel<TransactionSummariesViewModel, SbankenTransactionSummaryDto>(
                    response);
            }

            return new TransactionSummariesViewModel
            {
                Success = true,
                SbankenTransactionSummary = response.Data
            };
        }
    }
}