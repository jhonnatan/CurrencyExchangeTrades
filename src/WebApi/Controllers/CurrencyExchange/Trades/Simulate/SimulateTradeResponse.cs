namespace WebApi.Controllers.CurrencyExchange.Trades.Simulate
{
    public class SimulateTradeResponse
    {        
        public decimal AmountConverted { get; private set; }

        public SimulateTradeResponse(decimal amountConverted)
        {
            AmountConverted = amountConverted;
        }
    }
}