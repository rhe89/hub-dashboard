using Dashboard.Dto.Sbanken;
using Hub.Web.ViewModels;

namespace Dashboard.ViewModels.Sbanken
{
    public class InvestmentsViewModel : ApiResponseViewModel
    {
        public decimal Value { get; set; }
        public TransactionSummaryDto TransactionSummary { get; set; }
    }
}