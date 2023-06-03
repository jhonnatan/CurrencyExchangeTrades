namespace Infrastructure.DataAccess.Entities
{
    public class CurrencyExchangeTrade
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid AccountId { get; set; }
        public Guid DestinationAccountId { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
