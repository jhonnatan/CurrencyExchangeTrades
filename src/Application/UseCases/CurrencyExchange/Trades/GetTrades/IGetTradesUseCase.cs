namespace Application.UseCases.CurrencyExchange.Trades.GetTrades
{
    public interface IGetTradesUseCase
    {
        Task Execute(GetTradesUseCaseInput input);
    }
}
