namespace Domain.Dtos
{
    public class CurrencyExchangeTradesResponse
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public string AccountId { get; private set; }
        public string DestinationAccountId { get; private set; }
        public string CurrencyFrom { get; private set; }
        public string CurrencyTo { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public CurrencyExchangeTradesResponse(Guid id, Guid clientId, string accountId, string destinationAccountId, string currencyFrom, string currencyTo, decimal amount, DateTime transactionDate)
        {
            Id = id;
            ClientId = clientId;
            AccountId = accountId;
            DestinationAccountId = destinationAccountId;
            CurrencyFrom = currencyFrom;
            CurrencyTo = currencyTo;
            Amount = amount;
            TransactionDate = transactionDate;
        }
    }
}
