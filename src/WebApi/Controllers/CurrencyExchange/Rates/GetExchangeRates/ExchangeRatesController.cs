using Application.UseCases.CurrencyExchange.Rates.GetExchangeRates;
using Domain.CurrencyExchange.Rates.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace WebApi.Controllers.CurrencyExchange.Rates.GetExchangeRates
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IGetExchangeRatesUseCase _getExchangeRatesUseCase;
        private readonly GetExchangeRatesPresenter _presenter;
        private readonly ILogger<ExchangeRatesController> _logger;

        public ExchangeRatesController(IGetExchangeRatesUseCase getExchangeRatesUseCase,
            GetExchangeRatesPresenter presenter,
            ILogger<ExchangeRatesController> logger)
        {
            _getExchangeRatesUseCase = getExchangeRatesUseCase;
            _presenter = presenter;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(LatestRates), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] ExchangeRatesRequest request)
        {
            _logger.LogInformation($"Get exchange rates Requested at {DateTime.UtcNow} - Request: {JsonConvert.SerializeObject(request)}");
            IMemoryCache x;

            var input = new GetExchangeRatesUseCaseInput(request.CurrencyFrom, request.CurrenciesTo);
            await _getExchangeRatesUseCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
