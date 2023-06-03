namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade
{
    public interface ICreateTradeUseCase
    {
        Task Execute(CreateTradeUseCaseInput input);
    }
}
