using Dashboard.Integration.Dto.Sbanken;
using Hub.Web.BlazorServer.ViewModels;

namespace Dashboard.BlazorApp.ViewModels.Sbanken
{
    public class SbankenInvestmentsViewModel : ApiResponseViewModel
    {
        public decimal Value { get; set; }
        public SbankenTransactionSummaryDto SbankenTransactionSummary { get; set; }
    }
}