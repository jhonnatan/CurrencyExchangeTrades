namespace WebApi.Controllers.CurrencyExchange.Rates.GetExchangeRates
{
    public class CurrencyExchangeRatesResponse
    {
        public bool Success { get; private set; }

        public int Timestamp { get; private set; }

        public string Base { get; private set; }

        public string Date { get; private set; }

        public Dictionary<string, decimal> Rates { get; private set; }

        public CurrencyExchangeRatesResponse(bool success, int timestamp, string @base, string date, Dictionary<string, decimal> rates)
        {
            Success = success;
            Timestamp = timestamp;
            Base = @base;
            Date = date;
            Rates = rates;
        }
    }
}