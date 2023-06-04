using Application.Services;
using Domain.Dtos;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Json;

namespace Infrastructure.Services.CurrencyRates
{
    public class CurrencyRatesService : ICurrencyRatesService
    {
        public const string HttpClientName = "Fixer";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _cache;
        private string? baseUrl;
        private string? latestEndpoint;
        private string? accessKey;

        public CurrencyRatesService(IHttpClientFactory httpClientFactory, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            this._cache = cache;
        }

        /// <summary>
        /// Returns real-time exchange rate data for a specific currency.
        /// </summary>
        /// <param name="currencyFrom"></param>
        /// <param name="currenciesTo"></param>
        /// <returns>RateLatest</returns>
        public async Task<LatestRatesResponse?> GetLatestRates(string currencyFrom, List<string> currenciesTo)
        {
            var cacheKey = $"{currencyFrom}->{string.Join(",",currenciesTo)}";
            if (_cache.TryGetValue(cacheKey, out LatestRatesResponse? latestRatesCache))
                return latestRatesCache;
            
            CheckExchangeServiceVariables();

            HttpClient httpClient = this._httpClientFactory.CreateClient(HttpClientName);
            Uri requestUri = new Uri(
                $"{baseUrl}" +
                $"{latestEndpoint}" +
                $"?access_key={accessKey}" +
                $"&base={currencyFrom}" +
                $"&symbols={string.Join(",", currenciesTo)}");

            HttpResponseMessage response = await httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();
            var latestRates = await response.Content.ReadFromJsonAsync<LatestRatesResponse>();

            SetResultInCache(cacheKey, latestRates);            

            return latestRates;
        }        

        private void SetResultInCache(string cacheKey, LatestRatesResponse? latestRates)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()                
                .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                .SetPriority(CacheItemPriority.Normal);

            _cache.Set(cacheKey, latestRates, cacheEntryOptions);
        }

        private void CheckExchangeServiceVariables()
        {
            baseUrl = Environment.GetEnvironmentVariable("EXCHANGE_BASE_URL");
            latestEndpoint = Environment.GetEnvironmentVariable("EXCHANGE_LATEST_ENDPOINT");
            accessKey = Environment.GetEnvironmentVariable("EXCHANGE_ACCESS_KEY");

            if (string.IsNullOrEmpty(baseUrl)
                || string.IsNullOrEmpty(latestEndpoint)
                || string.IsNullOrEmpty(accessKey))
            {
                throw new ConfigurationValueMissingException("EXCHANGE_BASE_URL or EXCHANGE_LATEST_ENDPOINT or EXCHANGE_ACCESS_KEY are missing.");
            }
        }
    }
}
