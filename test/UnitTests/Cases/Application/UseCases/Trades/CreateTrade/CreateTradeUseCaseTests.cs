using Application.UseCases.CurrencyExchange.Trades.CreateTrade;
using FluentAssertions;
using UnitTests.Builders.CurrencyExchange;
using Xunit.Frameworks.Autofac;

namespace UnitTests.Cases.Application.UseCases.Trades.CreateTrade
{
    [UseAutofacTestFramework]
    public class CreateTradeUseCaseTests
    {
        private readonly ICreateTradeUseCase _createTradeUseCase;        

        public CreateTradeUseCaseTests(ICreateTradeUseCase createTradeUseCase)
        {
            this._createTradeUseCase = createTradeUseCase;            
        }

        [Fact]
        public void ShouldExecuteWithSuccess()
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, validData.From, validData.To, validData.Amount);
            _createTradeUseCase.Execute(input);
            input.ErrorOccured.Should().BeFalse();            
        }

        [Fact]        
        public void ShouldNotCompleteTradeWhenClientIdIsInvalid()
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(new Guid(), validData.AccountId, validData.DestinationAccountId, validData.From, validData.To, validData.Amount);
            _createTradeUseCase.Execute(input);
            input.ErrorOccured.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCompleteTradeWhenAccountIdIsInvalid(string accountId)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, accountId, validData.DestinationAccountId, validData.From, validData.To, validData.Amount);
            _createTradeUseCase.Execute(input);
            input.ErrorOccured.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCompleteTradeWhenDestinationAccountIdIsInvalid(string destinationAccountId)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, destinationAccountId, validData.From, validData.To, validData.Amount);
            _createTradeUseCase.Execute(input);
            input.ErrorOccured.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("EURRRR")]
        public void ShouldNotCompleteTradeWhenFromIsInvalid(string from)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, from, validData.To, validData.Amount);
            _createTradeUseCase.Execute(input);
            input.ErrorOccured.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("EURRRR")]
        public void ShouldNotCompleteTradeWhenToIsInvalid(string to)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, validData.From, to, validData.Amount);
            _createTradeUseCase.Execute(input);
            input.ErrorOccured.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-15)]
        public void ShouldNotCompleteTradeWhenAmountIsInvalid(decimal amount)
        {
            var validData = CurrencyExchangeTradeBuilder.New().Build();
            var input = new CreateTradeUseCaseInput(validData.ClientId, validData.AccountId, validData.DestinationAccountId, validData.From, validData.To, amount);
            _createTradeUseCase.Execute(input);
            input.ErrorOccured.Should().BeTrue();
        }
    }
}
