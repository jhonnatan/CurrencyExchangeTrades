using Application.Boundaries;
using Application.Services;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers
{
    public class GetLatestRateHandler : Handler<CreateTradeUseCaseInput>
    {
        private readonly ICurrencyRatesService _currencyRatesService;
        private readonly IOutputPort<CreateTradeUseCaseOutput> _outputPort;
        private readonly ILogger<GetLatestRateHandler> _logger;

        public GetLatestRateHandler(ICurrencyRatesService currencyRatesService,
            IOutputPort<CreateTradeUseCaseOutput> outputPort,
            ILogger<GetLatestRateHandler> logger)
        {
            this._currencyRatesService = currencyRatesService;
            this._outputPort = outputPort;
            this._logger = logger;
        }
        public override async Task ProcessRequest(CreateTradeUseCaseInput input)
        {            
            var latestRates = _currencyRatesService.GetLatestRates(input.From, new List<string>() { input.To }).GetAwaiter().GetResult();

            if (latestRates == null || latestRates.Success == false)
            {
                _outputPort.NotFound("You have provided one or more invalid Currency Codes. [Required format: currencies=EUR,USD,GBP,...]");
                _logger.LogInformation("You have provided one or more invalid Currency Codes. [Required format: currencies=EUR,USD,GBP,...]");
                return;
            }            

            var rate = latestRates.Rates.FirstOrDefault().Value;
            var convertedAmount = input.Amount * rate;
            input.SetRateAndConvertedAmount(rate, convertedAmount);

            sucessor?.ProcessRequest(input);
        }
    }
}
