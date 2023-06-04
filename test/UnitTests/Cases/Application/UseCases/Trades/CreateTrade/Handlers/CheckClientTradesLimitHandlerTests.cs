using Application.UseCases.CurrencyExchange.Trades.CreateTrade;
using Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers;
using FluentAssertions;
using UnitTests.Builders.CurrencyExchange;
using Xunit.Frameworks.Autofac;

namespace UnitTests.Cases.Application.UseCases.Trades.CreateTrade.Handlers
{
    [UseAutofacTestFramework]
    public class CheckClientTradesLimitHandlerTests
    {
        private readonly CheckClientTradesLimitHandler _checkClientTradesLimitHandler;

        public CheckClientTradesLimitHandlerTests(CheckClientTradesLimitHandler checkClientTradesLimitHandler)
        {
            this._checkClientTradesLimitHandler = checkClientTradesLimitHandler;
        }
        
        [Fact]
        public void ShouldExecuteWithSuccess()
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, validData.From, validData.To, validData.Amount);
            _checkClientTradesLimitHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotCompleteTradeWithInvalidCurrency()
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(new Guid("f40ae9d8-c5bf-415e-bfee-1fb35d435e64"), validData.AccountId, validData.DestinationAccountId, validData.From, validData.To, validData.Amount);
            _checkClientTradesLimitHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeTrue();
        }
    }
}
