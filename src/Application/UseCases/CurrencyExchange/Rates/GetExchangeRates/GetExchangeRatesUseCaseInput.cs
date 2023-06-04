namespace Application.UseCases.CurrencyExchange.Rates.GetExchangeRates
{
    public class GetExchangeRatesUseCaseInput
    {
        public string CurrencyFrom { get; private set; }
        public List<string> CurrenciesTo { get; private set; }
        public bool ErrorOccured { get; internal set; }

        public GetExchangeRatesUseCaseInput(string currencyFrom, List<string> currenciesTo)
        {
            CurrencyFrom = currencyFrom;
            CurrenciesTo = currenciesTo;
        }
    }
}