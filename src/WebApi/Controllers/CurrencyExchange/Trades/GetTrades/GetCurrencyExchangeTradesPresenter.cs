using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Trades.GetTrades;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CurrencyExchange.Trades.GetTrades
{
    public class GetCurrencyExchangeTradesPresenter : IOutputPort<GetTradesUseCaseOutput>
    {
        private readonly ILogger<GetCurrencyExchangeTradesPresenter> _logger;

        public IActionResult ViewModel { get; protected set; }
        public GetCurrencyExchangeTradesPresenter(ILogger<GetCurrencyExchangeTradesPresenter> logger)
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

        public void Standard(GetTradesUseCaseOutput output)
        {
            var trades = new List<CurrencyExchangeTradesResponse>();
            output.CurrencyExchangeTrades.ForEach(f => 
                trades.Add(new(
                    f.Id,
                    f.ClientId,
                    f.AccountId,
                    f.DestinationAccountId,
                    f.From,
                    f.To,
                    f.Amount,
                    f.Rate,
                    f.TransactionDate,
                    f.ConvertedAmount)));            
            ViewModel = new OkObjectResult(trades);
            _logger.LogInformation("GetTradesUseCase executed successfully");
        }
    }
}
