using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Trades.GetTrade;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CurrencyExchange.Trades.GetTrade
{
    public class GetCurrencyExchangeTradePresenter : IOutputPort<GetTradeUseCaseOutput>
    {
        public IActionResult ViewModel { get; protected set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };
            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(GetTradeUseCaseOutput output)
        {
            var response = new CurrencyExchangeTradesResponse(
                output.CurrencyExchangeTrade.Id,
                output.CurrencyExchangeTrade.ClientId,
                output.CurrencyExchangeTrade.AccountId,
                output.CurrencyExchangeTrade.DestinationAccountId,
                output.CurrencyExchangeTrade.CurrencyFrom,
                output.CurrencyExchangeTrade.CurrencyTo,
                output.CurrencyExchangeTrade.Amount,
                output.CurrencyExchangeTrade.TransactionDate);
            ViewModel = new OkObjectResult(response);
        }
    }
}
