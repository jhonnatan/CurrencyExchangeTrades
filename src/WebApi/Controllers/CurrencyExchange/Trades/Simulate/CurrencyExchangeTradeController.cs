using Application.UseCases.CurrencyExchange.Trades.Simulate;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("Simulate")]
        [ProducesResponseType(typeof(SimulateTradeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Simulate([FromBody] SimulateTradeRequest request)
        {
            _logger.LogInformation($"SimulateTrade Requested at {DateTime.UtcNow}");

            var input = new SimulateTradeUseCaseInput(request.CurrencyFrom, request.CurrencyTo, request.Amount);
            await _simulateTradeUseCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}