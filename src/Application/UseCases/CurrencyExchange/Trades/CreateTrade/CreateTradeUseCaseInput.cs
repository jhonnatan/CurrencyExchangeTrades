using Domain.CurrencyExchange;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade
{
    public class CreateTradeUseCaseInput
    {
        public CurrencyExchangeTrade CurrencyExchangeTrade { get; private set; }

        public CreateTradeUseCaseInput(CurrencyExchangeTrade currencyExchangeTrade)
        {
            CurrencyExchangeTrade = currencyExchangeTrade;
        }
    }
}