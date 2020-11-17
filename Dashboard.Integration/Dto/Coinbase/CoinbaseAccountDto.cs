namespace Dashboard.Integration.Dto.Coinbase
{
    public class CoinbaseAccountDto
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal LastMonthBalance { get; set; }
        public decimal LastYearBalance { get; set; }
    }
}
