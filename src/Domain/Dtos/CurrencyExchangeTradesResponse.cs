namespace Domain.Dtos
{
    public class CurrencyExchangeTradesResponse
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public string AccountId { get; private set; }
        public string DestinationAccountId { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public decimal ConvertedAmount { get; private set; }

        public CurrencyExchangeTradesResponse(Guid id, Guid clientId, string accountId, string destinationAccountId, string from, string to, decimal amount, decimal rate, DateTime transactionDate, decimal convertedAmount)
        {
            Id = id;
            ClientId = clientId;
            AccountId = accountId;
            DestinationAccountId = destinationAccountId;
            From = from;
            To = to;
            Amount = amount;
            Rate = rate;
            TransactionDate = transactionDate;
            ConvertedAmount = convertedAmount;
        }
    }
}
