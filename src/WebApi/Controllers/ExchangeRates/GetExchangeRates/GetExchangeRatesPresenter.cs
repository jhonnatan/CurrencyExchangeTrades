using Application.Boundaries;
using Application.UseCases.ExchangeRates.GetExchangeRates;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.ExchangeRates.GetExchangeRate;

namespace WebApi.Controllers.ExchangeRates.GetExchangeRates
{
    public class GetExchangeRatesPresenter : IOutputPort<GetExchangeRatesOutput>
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

        public void Standard(GetExchangeRatesOutput output)
        {
            var response = new ExchangeRatesResponse(output.LatestRates);
            ViewModel = new OkObjectResult(response);
        }
    }
}
