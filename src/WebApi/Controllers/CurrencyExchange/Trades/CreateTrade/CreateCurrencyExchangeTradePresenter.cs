using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Trades.CreateTrade;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CurrencyExchange.Trades.CreateTrade
{
    public class CreateCurrencyExchangeTradePresenter : IOutputPort<CreateTradeUseCaseOutput>
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

        public void Standard(CreateTradeUseCaseOutput output)
            =>  ViewModel = new OkObjectResult(output.Id);
        
    }
}
