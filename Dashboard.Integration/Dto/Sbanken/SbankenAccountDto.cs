using System.Collections.Generic;

namespace Dashboard.Integration.Dto.Sbanken
{
    public class SbankenAccountDto
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public IList<SbankenTransactionDto> Transactions { get; set; }
        public decimal LastMonthBalance { get; set; }
        public decimal LastYearBalance { get; set; }
    }
}