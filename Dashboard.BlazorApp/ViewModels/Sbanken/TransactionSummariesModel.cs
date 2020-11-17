using Dashboard.Integration.Dto.Sbanken;
using Hub.Web.BlazorServer.ViewModels;

namespace Dashboard.BlazorApp.ViewModels.Sbanken
{
    public class TransactionSummariesViewModel : ApiResponseViewModel
    {
        public SbankenTransactionSummaryDto SbankenTransactionSummary { get; set; }

    }
}