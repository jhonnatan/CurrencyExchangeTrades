using FluentAssertions;
using UnitTests.Builders.CurrencyExchange;

namespace UnitTests.Cases.Domain.CurrencyExchange
{
    public class CurrencyExchangeTradeTests
    {
        [Fact]
        public void ShouldCreateWithSuccess()
        {
            var model = CurrencyExchangeTradeBuilder.New().Build();
            model.Valid.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotCreateWithInvalidId()
        {
            var model = CurrencyExchangeTradeBuilder.New().WithId(new Guid()).Build();
            model.Valid.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotCreateWithInvalidClientId()
        {
            var model = CurrencyExchangeTradeBuilder.New().WithClientId(new Guid()).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldNotCreateWithNullOrEmptyAccountId(string accountId)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithAccountId(accountId).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]        
        [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s")]
        public void ShouldNotCreateWithMaxLenghtExceededAccountId(string accountId)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithAccountId(accountId).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldNotCreateWithNullOrEmptyDestinationAccountId(string destinationAccountId)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithDestinationAccountId(destinationAccountId).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s")]
        public void ShouldNotCreateWithMaxLenghtExceededDestinationAccountId(string destinationAccountId)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithDestinationAccountId(destinationAccountId).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldNotCreateWithNullOrEmptyFrom(string from)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithFrom(from).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData("EURRR")]
        public void ShouldNotCreateWithMaxLenghtExceededFrom(string from)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithFrom(from).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldNotCreateWithNullOrEmptyTo(string to)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithTo(to).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData("USDDD")]
        public void ShouldNotCreateWithMaxLenghtExceededTo(string to)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithTo(to).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]        
        [InlineData(0)]
        [InlineData(-150)]
        public void ShouldNotCreateWithInvalidAmount(decimal amount)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithAmount(amount).Build();
            model.Valid.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotCreateWithInvalidTransactionDate()
        {
            var model = CurrencyExchangeTradeBuilder.New().WithTransactionDate(new DateTime()).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-150)]
        public void ShouldNotCreateWithInvalidRate(decimal rate)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithRate(rate).Build();
            model.Valid.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-150)]
        public void ShouldNotCreateWithInvalidConvertedAmount(decimal convertedAmount)
        {
            var model = CurrencyExchangeTradeBuilder.New().WithConvertedAmount(convertedAmount).Build();
            model.Valid.Should().BeFalse();
        }
    }
}
