using Application.UseCases.ExchangeRates.GetExchangeRates;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Controllers.ExchangeRates.GetExchangeRates;

namespace WebApi.Controllers.ExchangeRates.GetExchangeRate
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
            this._getExchangeRatesUseCase = getExchangeRatesUseCase;
            this._presenter = presenter;
            this._logger = logger;
        }

        [HttpGet]                
        [ProducesResponseType(typeof(ExchangeRatesResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public async Task<IActionResult> Get([FromBody] ExchangeRatesRequest request)
        {
            _logger.LogInformation($"Get exchange rates Requested at {DateTime.UtcNow} - Request: {JsonConvert.SerializeObject(request)}");

            var input = new GetExchangeRatesUseCaseInput(request.CurrencyFrom, request.CurrenciesTo);
            await _getExchangeRatesUseCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
