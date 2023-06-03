using Application.UseCases.CurrencyExchange.Trades.GetTrades;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.CurrencyExchange.Trades.GetTrades
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExchangeTradeController : ControllerBase
    {
        private readonly ILogger<CurrencyExchangeTradeController> _logger;
        private readonly GetCurrencyExchangeTradesPresenter _presenter;
        private readonly IGetTradesUseCase _getTradesUseCase;

        public CurrencyExchangeTradeController(ILogger<CurrencyExchangeTradeController> logger,
            GetCurrencyExchangeTradesPresenter presenter,
            IGetTradesUseCase getTradeUseCase)
        {
            this._logger = logger;
            this._presenter = presenter;
            this._getTradesUseCase = getTradeUseCase;
        }
        // GET api/<CurrencyExchangeTradesController>/5
        [HttpGet("GetByClientId")]
        [ProducesResponseType(typeof(List<CurrencyExchangeTradesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTrades([FromQuery][Required] Guid clientId)
        {
            _logger.LogInformation($"GetCurrencyExchangeTradesByClientId Requested at {DateTime.UtcNow}");
            await _getTradesUseCase.Execute(new GetTradesUseCaseInput(clientId));
            return _presenter.ViewModel;
        }
    }
}
