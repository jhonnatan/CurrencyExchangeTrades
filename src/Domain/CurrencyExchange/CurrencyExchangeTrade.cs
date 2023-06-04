using Domain.Validator;

namespace Domain.CurrencyExchange
{
    public class CurrencyExchangeTrade : Entity
    {
        public Guid ClientId { get; private set; }
        public string AccountId { get; private set; }
        public string DestinationAccountId { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public decimal ConvertedAmount { get; private set; }

        protected CurrencyExchangeTrade() { }
        public CurrencyExchangeTrade(Guid clientId, string accountId, string destinationAccountId, string from, string to, decimal amount, decimal rate, decimal convertedAmount)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            AccountId = accountId;
            DestinationAccountId = destinationAccountId;
            From = from;
            To = to;
            Amount = amount;
            Rate = rate;
            ConvertedAmount = convertedAmount;
            TransactionDate = DateTime.UtcNow;

            Validate(this, new ExchangeTradeValidator());
        }        
    }
}
