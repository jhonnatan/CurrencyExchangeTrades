namespace Application.UseCases.CurrencyExchange.Trades.Simulate
{
    public interface ISimulateTradeUseCase
    {
        Task Execute(SimulateTradeUseCaseInput input);
    }
}
