namespace Application.UseCases.CurrencyExchange.Trades.Simulate
{
    public class SimulateTradeUseCaseOutput
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public decimal ConvertedAmount { get; private set; }
      
        public SimulateTradeUseCaseOutput(string currencyFrom, string currencyTo, decimal amount, decimal rate, decimal convertedAmount)
        {
            this.From = currencyFrom;
            this.To = currencyTo;
            this.Amount = amount;
            Rate = rate;
            this.ConvertedAmount = convertedAmount;
        }
    }
}
