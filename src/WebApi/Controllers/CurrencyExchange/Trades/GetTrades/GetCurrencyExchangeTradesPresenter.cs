using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Trades.GetTrades;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CurrencyExchange.Trades.GetTrades
{
    public class GetCurrencyExchangeTradesPresenter : IOutputPort<GetTradesUseCaseOutput>
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

        public void Standard(GetTradesUseCaseOutput output)
        {
            var trades = new List<CurrencyExchangeTradesResponse>();
            output.CurrencyExchangeTrades.ForEach(f => 
                trades.Add(new(
                    f.Id,
                    f.ClientId,
                    f.AccountId,
                    f.DestinationAccountId,
                    f.CurrencyFrom,
                    f.CurrencyTo,
                    f.Amount,
                    f.TransactionDate)));            
            ViewModel = new OkObjectResult(trades);
        }
    }
}
