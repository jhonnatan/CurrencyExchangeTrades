namespace Infrastructure.DataAccess.Entities
{
    public class CurrencyExchangeTrade
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string AccountId { get; set; }
        public string DestinationAccountId { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal ConvertedAmount { get; set; }
    }
}
