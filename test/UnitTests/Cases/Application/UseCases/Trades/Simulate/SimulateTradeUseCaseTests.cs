using Application.UseCases.CurrencyExchange.Trades.Simulate;
using UnitTests.Builders.CurrencyExchange;
using Xunit.Frameworks.Autofac;
using FluentAssertions;

namespace UnitTests.Cases.Application.UseCases.Trades.Simulate
{
    [UseAutofacTestFramework]
    public class SimulateTradeUseCaseTests
    {
        private readonly ISimulateTradeUseCase _simulateTradeUseCase;

        public SimulateTradeUseCaseTests(ISimulateTradeUseCase simulateTradeUseCase)
        {
            this._simulateTradeUseCase = simulateTradeUseCase;
        }

        [Fact]
        public void ShouldExecuteWithSuccess()
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new SimulateTradeUseCaseInput(validData.From, validData.To, validData.Amount);
            _simulateTradeUseCase.Execute(input);
            input.ErrorOccured.Should().BeFalse();
        }

        [Theory]
        [InlineData("notfound")]
        public void ShouldNotCompleteTradeWhenClientExceededLimit(string currencySymbol)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new SimulateTradeUseCaseInput(currencySymbol, currencySymbol, validData.Amount);
            _simulateTradeUseCase.Execute(input);
            input.ErrorOccured.Should().BeTrue();
        }
    }
}
