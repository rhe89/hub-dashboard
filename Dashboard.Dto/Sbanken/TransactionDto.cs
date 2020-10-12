using System;

namespace Dashboard.Dto.Sbanken
{
    public class TransactionDto
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string AccountName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TransactionType { get; set; }
    }
}