using Domain.CurrencyExchange;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade
{
    public class CreateTradeUseCaseInput
    {        
        public Guid ClientId { get; private set; }
        public string AccountId { get; private set; }
        public string DestinationAccountId { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public decimal ConvertedAmount { get; private set; }
        public CurrencyExchangeTrade CurrencyExchangeTrade { get; internal set; }
        public bool ErrorOccured { get; internal set; }

        public CreateTradeUseCaseInput(Guid clientId, string accountId, string destinationAccountId, string from, string to, decimal amount)
        {
            ClientId = clientId;
            AccountId = accountId;
            DestinationAccountId = destinationAccountId;
            From = from;
            To = to;
            Amount = amount;
        }
        public void SetRateAndConvertedAmount(decimal rate, decimal convertedAmount)
        {
            Rate = rate;
            ConvertedAmount = convertedAmount;
        }
    }
}