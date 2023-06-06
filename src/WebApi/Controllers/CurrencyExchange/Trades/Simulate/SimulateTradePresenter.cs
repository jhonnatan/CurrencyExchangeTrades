using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Trades.Simulate;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CurrencyExchange.Trades.Simulate
{
    public class SimulateTradePresenter : IOutputPort<SimulateTradeUseCaseOutput>
    {
        private readonly ILogger<SimulateTradePresenter> _logger;

        public IActionResult ViewModel { get; protected set; }
        public SimulateTradePresenter(ILogger<SimulateTradePresenter> logger)
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

        public void Standard(SimulateTradeUseCaseOutput output)
        {
            var query = new Query(output.From, output.To, output.Amount);
            var response = new SimulateTradeResponse(query, output.Rate, DateTime.UtcNow, output.ConvertedAmount);
            ViewModel = new OkObjectResult(response);
            _logger.LogInformation("SimulateTradeUseCase executed successfully");
        }
    }
}