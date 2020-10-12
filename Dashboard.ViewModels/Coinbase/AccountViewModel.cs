using System.Collections.Generic;
using Dashboard.Dto.Coinbase;
using Hub.Web.ViewModels;

namespace Dashboard.ViewModels.Coinbase
{
    public class AccountsViewModel : ApiResponseViewModel
    {
        public IList<AccountDto> Accounts { get; set; }
    }
}