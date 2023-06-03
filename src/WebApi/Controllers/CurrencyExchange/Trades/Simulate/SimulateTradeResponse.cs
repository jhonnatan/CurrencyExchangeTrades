namespace WebApi.Controllers.CurrencyExchange.Trades.Simulate
{
    public class SimulateTradeResponse
    {        
        public decimal ConvertedAmount { get; private set; }

        public SimulateTradeResponse(decimal convertedAmount)
        {
            ConvertedAmount = convertedAmount;
        }
    }
}