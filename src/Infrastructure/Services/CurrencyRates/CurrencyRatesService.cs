using Application.Services;
using Domain.ExchangeRates.Dtos;
using System.Net.Http.Json;

namespace Infrastructure.Services.CurrencyRates
{
    public class CurrencyRatesService : ICurrencyRatesService
    {
        public const string HttpClientName = "Fixer";
        private readonly IHttpClientFactory _httpClientFactory;        

        public CurrencyRatesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;            
        }

        /// <summary>
        /// Returns real-time exchange rate data for a specific currency.
        /// </summary>
        /// <param name="currencyFrom"></param>
        /// <param name="currenciesTo"></param>
        /// <returns>RateLatest</returns>
        public async Task<LatestRates?> GetLatestRates(string currencyFrom, List<string> currenciesTo)
        {
            HttpClient httpClient = this._httpClientFactory.CreateClient(HttpClientName);
            Uri requestUri = new Uri(
                $"{Environment.GetEnvironmentVariable("EXCHANGE_URL_BASE")}" +
                $"{Environment.GetEnvironmentVariable("EXCHANGE_LATEST_ENDPOINT")}" +
                $"?access_key={Environment.GetEnvironmentVariable("EXCHANGE_ACCESS_KEY")}" +
                $"&base={currencyFrom}" +
                $"&symbols={string.Join(",", currenciesTo)}");

            HttpResponseMessage response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();            
            return await response.Content.ReadFromJsonAsync<LatestRates>();
        }
    }
}
