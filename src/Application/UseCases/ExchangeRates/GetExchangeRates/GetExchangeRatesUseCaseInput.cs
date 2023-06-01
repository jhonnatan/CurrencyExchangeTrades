namespace Application.UseCases.ExchangeRates.GetExchangeRates
{
    public class GetExchangeRatesUseCaseInput
    {
        public string CurrencyFrom { get; private set; }
        public List<string> CurrenciesTo { get; private set; }

        public GetExchangeRatesUseCaseInput(string currencyFrom, List<string> currenciesTo)
        {
            CurrencyFrom = currencyFrom;
            CurrenciesTo = currenciesTo;
        }
    }
}