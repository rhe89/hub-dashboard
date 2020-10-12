using System;
using System.Collections.Generic;

namespace Dashboard.Dto.Sbanken
{
    public class TransactionSummaryDto
    {
        public decimal Balance { get; set; }
        public decimal TotalAmount { get; set; }
        public TransactionPeriodDto CurrentMonthTransactions { get; set; }
        public TransactionPeriodDto CurrentYearTransactions { get; set; }
        
        public bool DisplayBalance { get; set; }
    }

    public class TransactionPeriodDto
    {
        public decimal Amount { get; set; }
        public decimal PreviousPeriodAmount { get; set; }
        public IList<TransactionDto> Transactions { get; set; }
        public IList<TransactionDto> PreviousPeriodTransactions { get; set; }

        
        
    }
}