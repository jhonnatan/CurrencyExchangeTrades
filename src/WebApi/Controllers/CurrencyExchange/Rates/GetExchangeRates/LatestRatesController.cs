using Application.UseCases.CurrencyExchange.Rates.GetExchangeRates;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Annotations;

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
        /// <summary>
        /// Return real-time exchange rates from one currency base
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>        
        [HttpGet]
        [ProducesResponseType(typeof(LatestRatesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Return real-time exchange rates from one currency base",
            Description = "Return real-time exchange rates from one currency base from http://data.fixer.io/api/latest")]
        public async Task<IActionResult> GetLatestRates([FromQuery] GetCurrencyExchangeRatesRequest request)
        {
            _logger.LogInformation($"Get exchange rates Requested at {DateTime.UtcNow} - Request: {JsonConvert.SerializeObject(request)}");

            var input = new GetExchangeRatesUseCaseInput(request.CurrencyFrom, request.CurrenciesTo);
            await _getExchangeRatesUseCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
