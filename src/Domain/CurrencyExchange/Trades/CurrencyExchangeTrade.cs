using Domain.Validator;

namespace Domain.CurrencyExchange.Trades
{
    public class CurrencyExchangeTrade : Entity
    {
        public Guid ClientId { get; private set; }
        public Guid AccountId { get; private set; }
        public Guid DestinationAccountId { get; private set; }
        public string CurrencyFrom { get; private set; }
        public string CurrencyTo { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }

        protected CurrencyExchangeTrade() { }
        public CurrencyExchangeTrade(Guid clientId, Guid accountId, Guid destinationAccountId, string currencyFrom, string currencyTo, decimal amount)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            AccountId = accountId;
            DestinationAccountId = destinationAccountId;
            CurrencyFrom = currencyFrom;
            CurrencyTo = currencyTo;
            Amount = amount;
            TransactionDate = DateTime.UtcNow;

            Validate(this, new ExchangeTradeValidator());
        }
    }
}
