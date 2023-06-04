using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.CurrencyExchange.Trades.GetTrade;
using Xunit.Frameworks.Autofac;

namespace UnitTests.Cases.WebApi.Controllers.CurrencyExchange.Trades
{
    [UseAutofacTestFramework]
    public class GetTradeControllerTests
    {
        private readonly CurrencyExchangeTradeController _currencyExchangeTradeController;
        private readonly GetCurrencyExchangeTradePresenter _presenter;

        public GetTradeControllerTests(CurrencyExchangeTradeController currencyExchangeTradeController,
            GetCurrencyExchangeTradePresenter presenter)
        {
            this._currencyExchangeTradeController = currencyExchangeTradeController;
            this._presenter = presenter;
        }

        [Fact]
        public void ShouldExecuteAndGetOk()
        {
            _currencyExchangeTradeController.GetTrade(Guid.NewGuid()).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }
    }
}
