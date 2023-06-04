using Domain.CurrencyExchange;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade
{
    public class CreateTradeUseCaseOutput
    {        
        public CurrencyExchangeTrade Trade { get; private set; }

        public CreateTradeUseCaseOutput(CurrencyExchangeTrade currencyExchangeTrade)
        {
            Trade = currencyExchangeTrade;
        }
    }
}
