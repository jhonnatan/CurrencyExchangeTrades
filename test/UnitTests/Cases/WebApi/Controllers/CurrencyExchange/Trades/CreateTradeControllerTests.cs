using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using UnitTests.Builders.CurrencyExchange;
using WebApi.Controllers.CurrencyExchange.Trades.CreateTrade;
using Xunit.Frameworks.Autofac;

namespace UnitTests.Cases.WebApi.Controllers.CurrencyExchange.Trades
{
    [UseAutofacTestFramework]
    public class CreateTradeControllerTests
    {
        private readonly CurrencyExchangeTradeController _currencyExchangeTradeController;
        private readonly CreateCurrencyExchangeTradePresenter _presenter;

        public CreateTradeControllerTests(CurrencyExchangeTradeController currencyExchangeTradeController,
            CreateCurrencyExchangeTradePresenter presenter)
        {
            this._currencyExchangeTradeController = currencyExchangeTradeController;
            this._presenter = presenter;
        }

        [Fact]
        public void ShouldExecuteAndGetOK()
        {            
            _currencyExchangeTradeController.CreateTrade(GetValidRequest()).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotCompleteTradeWithInvalidClientId()
        {
            var request = GetValidRequest();
            request.Client.Id = new Guid();
            _currencyExchangeTradeController.CreateTrade(request).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCompleteTradeWithInvalidAccountId(string accountId)
        {
            var request = GetValidRequest();
            request.Client.AccountId = accountId;
            _currencyExchangeTradeController.CreateTrade(request).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCompleteTradeWithInvalidDestinationAccountId(string destinationAccountId)
        {
            var request = GetValidRequest();
            request.Client.DestinationAccountId = destinationAccountId;
            _currencyExchangeTradeController.CreateTrade(request).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory]
        [InlineData("notfound")]
        public void ShouldNotCompleteTradeWithInvalidFrom(string from)
        {
            var request = GetValidRequest();
            request.From = from;
            _currencyExchangeTradeController.CreateTrade(request).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory]
        [InlineData("notfound")]
        public void ShouldNotCompleteTradeWithInvalidTo(string to)
        {
            var request = GetValidRequest();
            request.To = to;
            _currencyExchangeTradeController.CreateTrade(request).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-15)]
        public void ShouldNotCompleteTradeWithInvalidAmount(decimal amount)
        {
            var request = GetValidRequest();
            request.Amount = amount;
            _currencyExchangeTradeController.CreateTrade(request).GetAwaiter();
            _presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        private CreateCurrencyExchangeTradeRequest GetValidRequest()
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            return new CreateCurrencyExchangeTradeRequest()
            {
                Client = new Client()
                {
                    Id = Guid.NewGuid(),
                    AccountId = validData.AccountId,
                    DestinationAccountId = validData.DestinationAccountId
                },
                Amount = validData.Amount,
                From = validData.From,
                To = validData.To
            };
        }
    }
}
