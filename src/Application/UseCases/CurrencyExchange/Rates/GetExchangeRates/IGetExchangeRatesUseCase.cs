namespace Application.UseCases.CurrencyExchange.Rates.GetExchangeRates
{
    public interface IGetExchangeRatesUseCase
    {
        Task Execute(GetExchangeRatesUseCaseInput input);
    }
}
