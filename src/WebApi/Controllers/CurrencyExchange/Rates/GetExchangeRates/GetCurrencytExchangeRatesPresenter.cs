using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Rates.GetExchangeRates;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CurrencyExchange.Rates.GetExchangeRates
{
    public class GetCurrencytExchangeRatesPresenter : IOutputPort<GetExchangeRatesOutput>
    {
        private readonly ILogger<GetCurrencytExchangeRatesPresenter> _logger;
        public IActionResult ViewModel { get; protected set; }

        public GetCurrencytExchangeRatesPresenter(ILogger<GetCurrencytExchangeRatesPresenter> logger)
        {
            this._logger = logger;            
        }

        public void Error(string message, string stackTrace)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };
            ViewModel = new BadRequestObjectResult(problemDetails);
            _logger.LogError(message, stackTrace);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
            _logger.LogInformation(message);
        }
        public void Standard(GetExchangeRatesOutput output)
        {
            GetCurrencyExchangeRatesResponse response = new(
                output.LatestRates.Success,
                output.LatestRates.Timestamp,
                output.LatestRates.Base,
                output.LatestRates.Date,
                output.LatestRates.Rates);
            ViewModel = new OkObjectResult(response);
            _logger.LogInformation("GetExchangeRatesUseCase executed successfully");
        }

    }
}
