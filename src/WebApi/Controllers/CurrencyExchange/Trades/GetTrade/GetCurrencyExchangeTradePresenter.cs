using Application.Boundaries;
using Application.UseCases.CurrencyExchange.Trades.GetTrade;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CurrencyExchange.Trades.GetTrade
{
    public class GetCurrencyExchangeTradePresenter : IOutputPort<GetTradeUseCaseOutput>
    {
        private readonly ILogger<GetCurrencyExchangeTradePresenter> _logger;

        public IActionResult ViewModel { get; protected set; }

        public GetCurrencyExchangeTradePresenter(ILogger<GetCurrencyExchangeTradePresenter> logger)
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
        public void Standard(GetTradeUseCaseOutput output)
        {
            var response = new CurrencyExchangeTradesResponse(
                output.CurrencyExchangeTrade.Id,
                output.CurrencyExchangeTrade.ClientId,
                output.CurrencyExchangeTrade.AccountId,
                output.CurrencyExchangeTrade.DestinationAccountId,
                output.CurrencyExchangeTrade.From,
                output.CurrencyExchangeTrade.To,
                output.CurrencyExchangeTrade.Amount,
                output.CurrencyExchangeTrade.Rate,
                output.CurrencyExchangeTrade.TransactionDate,
                output.CurrencyExchangeTrade.ConvertedAmount);
            ViewModel = new OkObjectResult(response);
            _logger.LogInformation("GetTradeUseCase executed successfully");
        }
    }
}
