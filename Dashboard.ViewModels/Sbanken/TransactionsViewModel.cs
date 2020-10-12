using System.Collections.Generic;
using Dashboard.Dto.Sbanken;
using Hub.Web.ViewModels;

namespace Dashboard.ViewModels.Sbanken
{
    public class TransactionsViewModel : ApiResponseViewModel
    {
        public IList<TransactionDto> Transactions { get; set; }
    }
}