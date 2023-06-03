using Domain.CurrencyExchange;

namespace Application.UseCases.CurrencyExchange.Trades.GetTrade
{
    public class GetTradeUseCaseOutput
    {
        public CurrencyExchangeTrade CurrencyExchangeTrade { get; private set; }

        public GetTradeUseCaseOutput(CurrencyExchangeTrade currencyExchangeTrade)
        {
            CurrencyExchangeTrade = currencyExchangeTrade;
        }
    }
}
