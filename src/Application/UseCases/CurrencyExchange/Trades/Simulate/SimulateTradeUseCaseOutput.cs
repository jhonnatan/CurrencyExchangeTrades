namespace Application.UseCases.CurrencyExchange.Trades.Simulate
{
    public class SimulateTradeUseCaseOutput
    {
        public decimal ConvertedAmount { get; private set; }

        public SimulateTradeUseCaseOutput(decimal amountConverted)
        {
            ConvertedAmount = amountConverted;
        }
    }
}
