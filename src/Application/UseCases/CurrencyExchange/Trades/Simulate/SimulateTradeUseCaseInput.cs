namespace Application.UseCases.CurrencyExchange.Trades.Simulate
{
    public class SimulateTradeUseCaseInput
    {
        public string CurrencyFrom { get; private set; }        
        public string CurrencyTo { get; private set; }        
        public decimal Amount { get; private set; }
        public bool ErrorOccured { get; internal set; }

        public SimulateTradeUseCaseInput(string currencyFrom, string currencyTo, decimal amount)
        {
            CurrencyFrom = currencyFrom;
            CurrencyTo = currencyTo;
            Amount = amount;
        }
    }
}