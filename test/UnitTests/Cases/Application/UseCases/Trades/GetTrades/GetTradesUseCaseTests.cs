using Application.UseCases.CurrencyExchange.Trades.GetTrades;
using Xunit.Frameworks.Autofac;
using WebApi.Controllers.CurrencyExchange.Trades.GetTrades;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Cases.Application.UseCases.Trades.GetTrades
{
    [UseAutofacTestFramework]
    public class GetTradesUseCaseTests
    {
        private readonly IGetTradesUseCase _getTradesUseCase;
        private readonly GetCurrencyExchangeTradesPresenter _presenter;

        public GetTradesUseCaseTests(IGetTradesUseCase getTradesUseCase,
            GetCurrencyExchangeTradesPresenter presenter)
        {
            this._getTradesUseCase = getTradesUseCase;
            this._presenter = presenter;
        }

        [Fact]
        public void ShouldExecuteWithSuccess()
        {            
            var input = new GetTradesUseCaseInput(Guid.NewGuid());
            _getTradesUseCase.Execute(input);
            _presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }
    }
}
