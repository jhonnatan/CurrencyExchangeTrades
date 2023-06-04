using Application.UseCases.CurrencyExchange.Trades.GetTrade;
using Xunit.Frameworks.Autofac;
using WebApi.Controllers.CurrencyExchange.Trades.GetTrade;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Cases.Application.UseCases.Trades.GetTrade
{
    [UseAutofacTestFramework]
    public class GetTradeUseCaseTests
    {
        private readonly IGetTradeUseCase _getTradeUseCase;
        private readonly GetCurrencyExchangeTradePresenter _presenter;

        public GetTradeUseCaseTests(IGetTradeUseCase getTradeUseCase,
            GetCurrencyExchangeTradePresenter presenter
            )
        {
            this._getTradeUseCase = getTradeUseCase;
            this._presenter = presenter;
        }

        [Fact]
        public void ShouldExecuteWithSuccess()
        {            
            var input = new GetTradeUseCaseInput(Guid.NewGuid());
            _getTradeUseCase.Execute(input);
            _presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }      
    }
}
