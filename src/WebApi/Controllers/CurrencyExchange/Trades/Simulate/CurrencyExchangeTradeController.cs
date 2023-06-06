using Application.UseCases.CurrencyExchange.Trades.Simulate;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers.CurrencyExchange.Trades.Simulate
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExchangeTradeController : ControllerBase
    {
        private readonly ILogger<CurrencyExchangeTradeController> _logger;
        private readonly ISimulateTradeUseCase _simulateTradeUseCase;        
        private readonly SimulateTradePresenter _presenter;

        public CurrencyExchangeTradeController(ILogger<CurrencyExchangeTradeController> logger,
            ISimulateTradeUseCase simulateTradeUseCase,
            SimulateTradePresenter presenter)
        {
            this._logger = logger;
            this._simulateTradeUseCase = simulateTradeUseCase;            
            this._presenter = presenter;
        }

        [HttpGet("Simulate")]
        [ProducesResponseType(typeof(SimulateTradeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Simulate currency exchange trades",
            Description = "Simulate currency exchange trades without any register")]
        public async Task<IActionResult> Simulate([FromQuery] SimulateTradeRequest request)
        {
            _logger.LogInformation($"SimulateTrade Requested at {DateTime.UtcNow}");

            var input = new SimulateTradeUseCaseInput(request.CurrencyFrom, request.CurrencyTo, request.Amount);
            await _simulateTradeUseCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}