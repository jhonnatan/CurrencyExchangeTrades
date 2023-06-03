namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade
{
    public class CreateTradeUseCaseOutput
    {
        public Guid Id { get; private set; }

        public CreateTradeUseCaseOutput(Guid id)
        {
            Id = id;
        }
    }
}
