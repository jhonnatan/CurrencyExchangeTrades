using Domain.CurrencyExchange.Rates.Dtos;

namespace Application.Services
{
    public interface ICurrencyRatesService
    {
        Task<LatestRates?> GetLatestRates(string currencyFrom, List<string> currenciesTo);
    }
}
