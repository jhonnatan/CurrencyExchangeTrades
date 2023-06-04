using Application.UseCases.CurrencyExchange.Rates.GetExchangeRates;
using FluentAssertions;
using Xunit.Frameworks.Autofac;

namespace UnitTests.Cases.Application.UseCases.Rates
{
    [UseAutofacTestFramework]
    public class GetExchangeRatesUseCaseTests
    {
        private readonly IGetExchangeRatesUseCase _getExchangeRatesUseCase;        

        public GetExchangeRatesUseCaseTests(IGetExchangeRatesUseCase getExchangeRatesUseCase)
        {
            this._getExchangeRatesUseCase = getExchangeRatesUseCase;            
        }

        [Fact]
        public void ShouldGetLatestRatesWithSuccess()
        {            
            var input = new GetExchangeRatesUseCaseInput("EUR", new List<string>() { "USD" });
            _getExchangeRatesUseCase.Execute(input);
            input.ErrorOccured.Should().BeFalse();            
        }

        [Fact]
        public void ShouldGetLatestRatesWithErrorWithInvalidCurrency()
        {           
            var input = new GetExchangeRatesUseCaseInput("notfound", new List<string>() { "notfound" });
            _getExchangeRatesUseCase.Execute(input);
            input.ErrorOccured.Should().BeTrue();
        }
    }
}
