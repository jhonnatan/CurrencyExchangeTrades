using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Trades.CreateTrade;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CurrencyExchange.Trades.CreateTrade
{
    public class CreateCurrencyExchangeTradePresenter : IOutputPort<CreateTradeUseCaseOutput>
    {
        private readonly ILogger<CreateCurrencyExchangeTradePresenter> _logger;

        public CreateCurrencyExchangeTradePresenter(ILogger<CreateCurrencyExchangeTradePresenter> logger)
        {
            this._logger = logger;
        }
        public IActionResult ViewModel { get; protected set; }

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

        public void Standard(CreateTradeUseCaseOutput output)
        {
            var query = new Query(output.Trade.From, output.Trade.To, output.Trade.Amount);
            var response = new CreateExchangeTradeResponse(query, output.Trade.Id, output.Trade.Rate, output.Trade.TransactionDate, output.Trade.ConvertedAmount);
            ViewModel = new OkObjectResult(response);
            _logger.LogInformation("CreateTradeUseCase executed successfully");

        }
    }
}
