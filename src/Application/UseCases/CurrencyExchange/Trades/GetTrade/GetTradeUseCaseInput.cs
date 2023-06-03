namespace Application.UseCases.CurrencyExchange.Trades.GetTrade
{
    public class GetTradeUseCaseInput
    {
        public Guid Id { get; private set; }

        public GetTradeUseCaseInput(Guid id)
        {
            Id = id;
        }
    }
}