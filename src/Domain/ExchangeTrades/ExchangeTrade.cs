using Domain.Validator;

namespace Domain.ExchangeTrades
{
    public class ExchangeTrade : Entity
    {
        public Guid ClientId { get; private set; }
        public Guid AccountId { get; private set; }
        public Guid DestinationAccountId { get; private set; }
        public string CurrencyFrom { get; private set; }
        public string CurrencyTo { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public ExchangeTrade(Guid clientId, Guid accountId, Guid destinationAccountId, string currencyFrom, string currencyTo, decimal amount, DateTime transactionDate)
        {
            ClientId = clientId;
            AccountId = accountId;
            DestinationAccountId = destinationAccountId;
            CurrencyFrom = currencyFrom;
            CurrencyTo = currencyTo;
            Amount = amount;
            TransactionDate = transactionDate;

            Validate(this, new ExchangeTradeValidator());
        }
    }
}
