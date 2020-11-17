using System.Collections.Generic;
using Dashboard.Integration.Dto.Sbanken;
using Hub.Web.BlazorServer.ViewModels;

namespace Dashboard.BlazorApp.ViewModels.Sbanken
{
    public class TransactionsViewModel : ApiResponseViewModel
    {
        public IList<SbankenTransactionDto> Transactions { get; set; }
    }
}