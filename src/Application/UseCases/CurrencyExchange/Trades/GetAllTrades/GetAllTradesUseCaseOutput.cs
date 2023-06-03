using Domain.CurrencyExchange.Trades;

namespace Application.UseCases.CurrencyExchange.Trades.GetAllTrades
{
    public class GetAllTradesUseCaseOutput
    {
        public List<CurrencyExchangeTrade> CurrencyExchangeTrades { get; private set; }

        public GetAllTradesUseCaseOutput(List<CurrencyExchangeTrade> currencyExchangeTrades)
        {
            CurrencyExchangeTrades = currencyExchangeTrades;
        }
    }
}
