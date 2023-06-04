using Application.UseCases.CurrencyExchange.Rates.GetExchangeRates;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers.CurrencyExchange.Rates.GetExchangeRates
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatestRatesController : ControllerBase
    {
        private readonly IGetExchangeRatesUseCase _getExchangeRatesUseCase;
        private readonly GetCurrencytExchangeRatesPresenter _presenter;
        private readonly ILogger<LatestRatesController> _logger;

        public LatestRatesController(IGetExchangeRatesUseCase getExchangeRatesUseCase,
            GetCurrencytExchangeRatesPresenter presenter,
            ILogger<LatestRatesController> logger)
        {
            _getExchangeRatesUseCase = getExchangeRatesUseCase;
            _presenter = presenter;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(LatestRatesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] GetCurrencyExchangeRatesRequest request)
        {
            _logger.LogInformation($"Get exchange rates Requested at {DateTime.UtcNow} - Request: {JsonConvert.SerializeObject(request)}");            

            var input = new GetExchangeRatesUseCaseInput(request.CurrencyFrom, request.CurrenciesTo);
            await _getExchangeRatesUseCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
