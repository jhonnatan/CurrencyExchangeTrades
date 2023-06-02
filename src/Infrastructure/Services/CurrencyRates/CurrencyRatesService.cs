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
            var baseUrl = Environment.GetEnvironmentVariable("EXCHANGE_BASE_URL");
            var latestEndpoint = Environment.GetEnvironmentVariable("EXCHANGE_LATEST_ENDPOINT");
            var accessKey = Environment.GetEnvironmentVariable("EXCHANGE_ACCESS_KEY");

            CheckExchangeServiceVariables(baseUrl, latestEndpoint, accessKey);

            HttpClient httpClient = this._httpClientFactory.CreateClient(HttpClientName);
            Uri requestUri = new Uri(
                $"{baseUrl}" +
                $"{latestEndpoint}" +
                $"?access_key={accessKey}" +
                $"&base={currencyFrom}" +
                $"&symbols={string.Join(",", currenciesTo)}");

            HttpResponseMessage response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LatestRates>();
        }

        private static void CheckExchangeServiceVariables(string? baseUrl, string? latestEndpoint, string? accessKey)
        {
            if (string.IsNullOrEmpty(baseUrl)
                || string.IsNullOrEmpty(latestEndpoint)
                || string.IsNullOrEmpty(accessKey))
            {
                throw new ConfigurationValueMissingException("EXCHANGE_BASE_URL or EXCHANGE_LATEST_ENDPOINT or EXCHANGE_ACCESS_KEY is missing.");
            }
        }
    }
}
