using Application.UseCases.CurrencyExchange.Trades.CreateTrade;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers.CurrencyExchange.Trades.CreateTrade
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExchangeTradeController : ControllerBase
    {
        private readonly ILogger<CurrencyExchangeTradeController> _logger;
        private readonly ICreateTradeUseCase _createTradeUseCase;
        private readonly CreateCurrencyExchangeTradePresenter _presenter;

        public CurrencyExchangeTradeController(ILogger<CurrencyExchangeTradeController> logger,
            ICreateTradeUseCase createTradeUseCase,
            CreateCurrencyExchangeTradePresenter presenter)
        {
            this._logger = logger;
            this._createTradeUseCase = createTradeUseCase;
            this._presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateExchangeTradeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Register currency exchange trades carried out by its clients",
            Description = "Register currency exchange trades carried out by its clients")]
        public async Task<IActionResult> CreateTrade([FromBody] CreateCurrencyExchangeTradeRequest request)
        {
            _logger.LogInformation($"CreateCurrencyExchangeTrade Executed at {DateTime.UtcNow}");

            var input = new CreateTradeUseCaseInput(
                request.Client.Id,
                request.Client.AccountId,
                request.Client.DestinationAccountId,
                request.From,
                request.To,
                request.Amount);
            await _createTradeUseCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
