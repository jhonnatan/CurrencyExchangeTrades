using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.CurrencyExchange.Rates.GetExchangeRates;
using Xunit.Frameworks.Autofac;

namespace UnitTests.Cases.WebApi.Controllers.CurrencyExchange.Rates.GetExchangeRates
{
    [UseAutofacTestFramework]
    public class LatestRatesControllerTests
    {
        private readonly LatestRatesController _latestRatesController;
        private readonly GetCurrencytExchangeRatesPresenter _presenter;

        public LatestRatesControllerTests(LatestRatesController latestRatesController,
            GetCurrencytExchangeRatesPresenter presenter)
        {
            this._latestRatesController = latestRatesController;
            this._presenter = presenter;
        }

        [Fact]
        public void ShouldExecuteAndGetOK()
        {
            var request = new GetCurrencyExchangeRatesRequest()
            {
                CurrencyFrom = "EUR",
                CurrenciesTo = new List<string>() { "USD" }
            };
            _latestRatesController.GetLatestRates(request).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldExecuteAndGetNotFoundWithInvalidCurrencies()
        {
            var request = new GetCurrencyExchangeRatesRequest()
            {
                CurrencyFrom = "notfound",
                CurrenciesTo = new List<string>() { "notfound" }
            };
            _latestRatesController.GetLatestRates(request).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
