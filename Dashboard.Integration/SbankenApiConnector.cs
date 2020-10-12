using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dashboard.Dto.Sbanken;
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

        public async Task<Response<TransactionDto[]>> GetTransactions(int ageInDays)
        {
            return await Get<TransactionDto[]>(TransactionsPath, $"ageInDays={ageInDays}");
        }
        
        public async Task<Response<TransactionSummaryDto>> GetMikrosparTransactions()
        {
            return await Get<TransactionSummaryDto>(MikrosparTransactionsPath);
        }
        
        public async Task<Response<TransactionSummaryDto>> GetInvestmentTransactions()
        {
            return await Get<TransactionSummaryDto>(InvestmentTransactionsPath);
        }
        
        public async Task<Response<IList<AccountDto>>> GetSavingsAccounts()
        {
            return await Get<IList<AccountDto>>(SavingAccountsPath);
        }
        
        public async Task<Response<IList<AccountDto>>> GetStandardAccounts()
        {
            return await Get<IList<AccountDto>>(StandardAccountsPath);
        }
        
        public async Task<Response<IList<AccountDto>>> GetCreditAccounts()
        {
            return await Get<IList<AccountDto>>(CreditAccountsPath);
        }
    }
}