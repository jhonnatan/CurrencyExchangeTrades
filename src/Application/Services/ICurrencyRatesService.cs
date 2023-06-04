using Domain.Dtos;

namespace Application.Services
{
    public interface ICurrencyRatesService
    {
        Task<LatestRatesResponse?> GetLatestRates(string currencyFrom, List<string> currenciesTo);
    }
}
