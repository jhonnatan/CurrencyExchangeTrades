namespace Application.UseCases.CurrencyExchange.Trades.GetTrade
{
    public interface IGetTradeUseCase
    {
        Task Execute(GetTradeUseCaseInput input);
    }
}
