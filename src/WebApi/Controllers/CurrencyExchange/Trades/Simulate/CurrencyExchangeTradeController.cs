using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CurrencyExchange.Trades.Simulate
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExchangeTradeController : ControllerBase
    {
        private readonly ILogger<CurrencyExchangeTradeController> _logger;
        // private readonly ICreateTradeUseCase _createTradeUseCase;
        private readonly SimulateTradePresenter _presenter;

        public CurrencyExchangeTradeController(ILogger<CurrencyExchangeTradeController> logger,
            // ICreateTradeUseCase createTradeUseCase,
            SimulateTradePresenter presenter)
        {
            this._logger = logger;
            //this._createTradeUseCase = createTradeUseCase;
            this._presenter = presenter;
        }

        [HttpPost("Simulate")]
        [ProducesResponseType(typeof(SimulateTradeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Simulate([FromBody] SimulateTradeRequest request)
        {
            _logger.LogInformation($"SimulateTrade Requested at {DateTime.UtcNow}");

            //await _createTradeUseCase.Execute(new CreateTradeUseCaseInput(model));
            return _presenter.ViewModel;
        }
    }
}