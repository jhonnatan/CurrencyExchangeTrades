using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.CurrencyExchange.Trades.GetTrades;
using Xunit.Frameworks.Autofac;

namespace UnitTests.Cases.WebApi.Controllers.CurrencyExchange.Trades
{
    [UseAutofacTestFramework]
    public class GetTradesControllerTests
    {
        private readonly CurrencyExchangeTradeController _currencyExchangeTradeController;
        private readonly GetCurrencyExchangeTradesPresenter _presenter;

        public GetTradesControllerTests(CurrencyExchangeTradeController currencyExchangeTradeController,
            GetCurrencyExchangeTradesPresenter presenter)
        {
            this._currencyExchangeTradeController = currencyExchangeTradeController;
            this._presenter = presenter;
        }

        [Fact]
        public void ShouldExecuteAndGetOk()
        {
            _currencyExchangeTradeController.GetTrades(Guid.NewGuid()).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }
    }
}
