using Application.UseCases.CurrencyExchange.Trades.CreateTrade;
using Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers;
using FluentAssertions;
using UnitTests.Builders.CurrencyExchange;
using Xunit.Frameworks.Autofac;

namespace UnitTests.Cases.Application.UseCases.Trades.CreateTrade.Handlers
{
    [UseAutofacTestFramework]
    public class SaveExchangeTradeHandlerTests
    {
        private readonly SaveExchangeTradeHandler _saveExchangeTradeHandler;

        public SaveExchangeTradeHandlerTests(SaveExchangeTradeHandler saveExchangeTradeHandler)
        {
            this._saveExchangeTradeHandler = saveExchangeTradeHandler;
        }

        [Fact]
        public void ShouldExecuteWithSuccess()
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, validData.From, validData.To, validData.Amount);
            input.SetRateAndConvertedAmount(5, 1000);
            _saveExchangeTradeHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeFalse();
        }

        [Fact]
        public void ShouldGetErrorWhenClientIdIsInvalid()
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(new Guid(), validData.AccountId, validData.DestinationAccountId, validData.From, validData.To, validData.Amount);
            input.SetRateAndConvertedAmount(5, 1000);
            _saveExchangeTradeHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldGetErrorWhenAccountIdIsInvalid(string accountId)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, accountId, validData.DestinationAccountId, validData.From, validData.To, validData.Amount);
            input.SetRateAndConvertedAmount(5, 1000);
            _saveExchangeTradeHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldGetErrorWhenDestinationAccountIdIsInvalid(string destinationAccountId)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, destinationAccountId, validData.From, validData.To, validData.Amount);
            input.SetRateAndConvertedAmount(5, 1000);
            _saveExchangeTradeHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("EURRRR")]
        public void ShouldGetErrorWhenFromIsInvalid(string from)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, from, validData.To, validData.Amount);
            input.SetRateAndConvertedAmount(5, 1000);
            _saveExchangeTradeHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("EURRRR")]
        public void ShouldGetErrorWhenToIsInvalid(string to)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, validData.From, to, validData.Amount);
            input.SetRateAndConvertedAmount(5, 1000);
            _saveExchangeTradeHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-15)]
        public void ShouldGetErrorWhenAmountIsInvalid(decimal amount)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, validData.From, validData.To, amount);
            input.SetRateAndConvertedAmount(5, 1000);
            _saveExchangeTradeHandler.ProcessRequest(input).GetAwaiter();
            input.ErrorOccured.Should().BeTrue();
        }
    }
}
