using Domain.CurrencyExchange;
using Domain.Repositories.Command;
using Moq;
using UnitTests.Builders.CurrencyExchange;

namespace UnitTests.Mock.Infrastructure.Repositories.ExchangeTrade
{
    public class CurrencyExchangeTradeCommandRepositoryMock
    {
        public Mock<ICurrencyExchangeTradeCommandRepository> MockRepository()
        {
            var accountDetailsRepositoryMock = new Mock<ICurrencyExchangeTradeCommandRepository>();

            // AddAsync
            accountDetailsRepositoryMock.Setup(i => i.AddAsync(It.IsAny<CurrencyExchangeTrade>()))
                .Returns(Task.FromResult(CurrencyExchangeTradeBuilder.New().Build()));

            // UpdateAsync
            accountDetailsRepositoryMock.Setup(i => i.UpdateAsync(It.IsAny<CurrencyExchangeTrade>()))
                .Returns(Task.FromResult(CurrencyExchangeTradeBuilder.New().Build()));

            // DeleteAsync
            accountDetailsRepositoryMock.Setup(i => i.DeleteAsync(It.IsAny<CurrencyExchangeTrade>()))
                .Returns(Task.FromResult(CurrencyExchangeTradeBuilder.New().Build()));

            return accountDetailsRepositoryMock;
        }
    }
}
