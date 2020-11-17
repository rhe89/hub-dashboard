using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Integration.Dto.Sbanken;
using Hub.Web.Http;

namespace Dashboard.Integration
{
    public interface ISbankenApiConnector
    {
        Task<Response<SbankenTransactionDto[]>> GetTransactions(int ageInDays);
        Task<Response<SbankenTransactionSummaryDto>> GetMikrosparTransactions();
        Task<Response<SbankenTransactionSummaryDto>> GetInvestmentTransactions();
        Task<Response<IList<SbankenAccountDto>>> GetSavingsAccounts();
        Task<Response<IList<SbankenAccountDto>>> GetStandardAccounts();
        Task<Response<IList<SbankenAccountDto>>> GetCreditAccounts();
    }
}