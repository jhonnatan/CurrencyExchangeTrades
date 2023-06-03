namespace WebApi.Controllers.CurrencyExchange.Trades.CreateTrade
{
    public class CreateCurrencyExchangeTradeResponse
    {
        public Guid Id { get; private set; }

        public CreateCurrencyExchangeTradeResponse(Guid id)
        {
            Id = id;
        }
    }
}
