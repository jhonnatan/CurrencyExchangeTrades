using Application.Boundaries;
using Application.Services;

namespace Application.UseCases.CurrencyExchange.Trades.CreateTrade.Handlers
{
    public class GetLatestRateHandler : Handler<CreateTradeUseCaseInput>
    {
        private readonly ICurrencyRatesService _currencyRatesService;
        private readonly IOutputPort<CreateTradeUseCaseOutput> _outputPort;        

        public GetLatestRateHandler(ICurrencyRatesService currencyRatesService,
            IOutputPort<CreateTradeUseCaseOutput> outputPort)
        {
            this._currencyRatesService = currencyRatesService;
            this._outputPort = outputPort;            
        }
        public override async Task ProcessRequest(CreateTradeUseCaseInput input)
        {            
            var latestRates = _currencyRatesService.GetLatestRates(input.From, new List<string>() { input.To }).GetAwaiter().GetResult();

            if (latestRates == null || latestRates.Success == false)
            {
                _outputPort.NotFound("Base currency access restricted or you have provided one or more invalid currency codes. [Required format: currencies=EUR,USD,GBP,...]");                
                input.ErrorOccured = true;
                return;
            }            

            var rate = latestRates.Rates.FirstOrDefault().Value;
            var convertedAmount = input.Amount * rate;
            input.SetRateAndConvertedAmount(rate, convertedAmount);

            sucessor?.ProcessRequest(input);
        }
    }
}
