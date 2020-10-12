using System.Collections.Generic;
using Dashboard.Dto.Sbanken;
using Hub.Web.ViewModels;

namespace Dashboard.ViewModels.Sbanken
{
    public class AccountsViewModel : ApiResponseViewModel
    {
        public IList<AccountDto> Accounts { get; set; }
    }
}