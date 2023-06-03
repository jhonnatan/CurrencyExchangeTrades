using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Rates.GetExchangeRates;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CurrencyExchange.Rates.GetExchangeRates
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
            ExchangeRatesResponse response = new(
                output.LatestRates.Success,
                output.LatestRates.Timestamp,
                output.LatestRates.Base,
                output.LatestRates.Date,
                output.LatestRates.Rates);
            ViewModel = new OkObjectResult(response);
        }

    }
}
