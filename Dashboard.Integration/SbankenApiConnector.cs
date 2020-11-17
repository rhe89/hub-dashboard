using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dashboard.Integration.Dto.Sbanken;
using Hub.Web.Http;
using Microsoft.Extensions.Logging;

namespace Dashboard.Integration
{
    public class SbankenApiConnector : HttpClientService, ISbankenApiConnector
    {
        private const string StandardAccountsPath = "/api/account/standard";
        private const string CreditAccountsPath = "/api/account/credit";
        private const string SavingAccountsPath = "/api/account/savings";
        private const string TransactionsPath = "/api/transaction/transactions";
        private const string MikrosparTransactionsPath = "/api/transaction/mikrospar";
        private const string InvestmentTransactionsPath = "/api/transaction/investments";

        public SbankenApiConnector(HttpClient httpClient, ILogger<SbankenApiConnector> logger) : base(httpClient, logger, "SbankenApi") {}

        public async Task<Response<SbankenTransactionDto[]>> GetTransactions(int ageInDays)
        {
            return await Get<SbankenTransactionDto[]>(TransactionsPath, $"ageInDays={ageInDays}");
        }
        
        public async Task<Response<SbankenTransactionSummaryDto>> GetMikrosparTransactions()
        {
            return await Get<SbankenTransactionSummaryDto>(MikrosparTransactionsPath);
        }
        
        public async Task<Response<SbankenTransactionSummaryDto>> GetInvestmentTransactions()
        {
            return await Get<SbankenTransactionSummaryDto>(InvestmentTransactionsPath);
        }
        
        public async Task<Response<IList<SbankenAccountDto>>> GetSavingsAccounts()
        {
            return await Get<IList<SbankenAccountDto>>(SavingAccountsPath);
        }
        
        public async Task<Response<IList<SbankenAccountDto>>> GetStandardAccounts()
        {
            return await Get<IList<SbankenAccountDto>>(StandardAccountsPath);
        }
        
        public async Task<Response<IList<SbankenAccountDto>>> GetCreditAccounts()
        {
            return await Get<IList<SbankenAccountDto>>(CreditAccountsPath);
        }
    }
}