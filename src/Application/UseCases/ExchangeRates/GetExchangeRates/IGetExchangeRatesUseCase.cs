namespace Application.UseCases.ExchangeRates.GetExchangeRates
{
    public interface IGetExchangeRatesUseCase
    {
        Task Execute(GetExchangeRatesUseCaseInput input);
    }
}
