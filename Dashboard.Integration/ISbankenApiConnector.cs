using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Dto.Sbanken;
using Hub.Web.Http;

namespace Dashboard.Integration
{
    public interface ISbankenApiConnector
    {
        Task<Response<TransactionDto[]>> GetTransactions(int ageInDays);
        Task<Response<TransactionSummaryDto>> GetMikrosparTransactions();
        Task<Response<TransactionSummaryDto>> GetInvestmentTransactions();
        Task<Response<IList<AccountDto>>> GetSavingsAccounts();
        Task<Response<IList<AccountDto>>> GetStandardAccounts();
        Task<Response<IList<AccountDto>>> GetCreditAccounts();
    }
}