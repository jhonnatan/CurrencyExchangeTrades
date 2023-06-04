using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.CurrencyExchange.Trades.Simulate;
using Xunit.Frameworks.Autofac;

namespace UnitTests.Cases.WebApi.Controllers.CurrencyExchange.Trades
{
    [UseAutofacTestFramework]
    public class SimulateControllerTests
    {
        private readonly CurrencyExchangeTradeController _currencyExchangeTradeController;
        private readonly SimulateTradePresenter _presenter;

        public SimulateControllerTests(CurrencyExchangeTradeController currencyExchangeTradeController,
            SimulateTradePresenter presenter)
        {
            this._currencyExchangeTradeController = currencyExchangeTradeController;
            this._presenter = presenter;
        }

        [Fact]
        public void ShouldExecuteAndGetOk()
        {
            var request = new SimulateTradeRequest()
            {
                CurrencyFrom = "EUR",
                CurrencyTo = "USD",
                Amount = 1000
            };
            _currencyExchangeTradeController.Simulate(request).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldExecuteAndGetNotFoundWithInvalidCurrencies()
        {
            var request = new SimulateTradeRequest()
            {
                CurrencyFrom = "notfound",
                CurrencyTo = "notfound",
                Amount = 1000
            };
            _currencyExchangeTradeController.Simulate(request).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
