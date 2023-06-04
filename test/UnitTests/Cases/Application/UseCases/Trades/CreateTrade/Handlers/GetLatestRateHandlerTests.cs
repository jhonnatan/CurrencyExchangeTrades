using Application.UseCases.CurrencyExchange.Trades.CreateTrade;
using Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers;
using FluentAssertions;
using UnitTests.Builders.CurrencyExchange;
using Xunit.Frameworks.Autofac;

namespace UnitTests.Cases.Application.UseCases.Trades.CreateTrade.Handlers
{
    [UseAutofacTestFramework]
    public class GetLatestRateHandlerTests
    {
        private readonly GetLatestRateHandler _getLatestRateHandler;

        public GetLatestRateHandlerTests(GetLatestRateHandler getLatestRateHandler)
        {
            this._getLatestRateHandler = getLatestRateHandler;
        }

        [Fact]
        public void ShouldExecuteWithSuccess()
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, validData.From, validData.To, validData.Amount);
            _getLatestRateHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeFalse();
        }

        [Theory]
        [InlineData("notfound")]
        public void ShouldNotCompleteTradeWhenClientExceededLimit(string currencySymbol)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, currencySymbol, currencySymbol, validData.Amount);
            _getLatestRateHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeTrue();
        }
    }
}
