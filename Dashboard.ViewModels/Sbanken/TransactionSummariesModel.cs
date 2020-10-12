using Dashboard.Dto.Sbanken;
using Hub.Web.ViewModels;

namespace Dashboard.ViewModels.Sbanken
{
    public class TransactionSummariesViewModel : ApiResponseViewModel
    {
        public TransactionSummaryDto TransactionSummary { get; set; }

    }
}