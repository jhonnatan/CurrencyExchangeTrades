using Domain.CurrencyExchange;

namespace Application.UseCases.CurrencyExchange.Trades.GetTrades
{
    public class GetTradesUseCaseOutput
    {
        public List<CurrencyExchangeTrade> CurrencyExchangeTrades { get; private set; }

        public GetTradesUseCaseOutput(List<CurrencyExchangeTrade> currencyExchangeTrades)
        {
            CurrencyExchangeTrades = currencyExchangeTrades;
        }
    }
}
