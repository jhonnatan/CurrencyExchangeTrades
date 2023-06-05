﻿using Application.Boundaries;
using Application.Services;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.CurrencyExchange.Rates.GetExchangeRates
{
    public class GetExchangeRatesUseCase : IGetExchangeRatesUseCase
    {
        private readonly ILogger<GetExchangeRatesUseCase> _logger;
        private readonly IOutputPort<GetExchangeRatesOutput> _outputPort;
        private readonly ICurrencyRatesService _currencyRatesService;

        public GetExchangeRatesUseCase(ILogger<GetExchangeRatesUseCase> logger,
            IOutputPort<GetExchangeRatesOutput> outputPort,
            ICurrencyRatesService currencyRatesService)
        {
            this._logger = logger;
            _outputPort = outputPort;
            _currencyRatesService = currencyRatesService;
        }
        public async Task Execute(GetExchangeRatesUseCaseInput input)
        {
            try
            {
                var latestRates = await _currencyRatesService.GetLatestRates(input.CurrencyFrom, input.CurrenciesTo);
                if (latestRates == null || latestRates.Success == false)
                {
                    _logger.LogWarning("Base currency access restricted or you have provided one or more invalid currency codes. [Required format: currencies=EUR,USD,GBP,...]");
                    _outputPort.NotFound("Base currency access restricted or you have provided one or more invalid currency codes. [Required format: currencies=EUR,USD,GBP,...]");
                    input.ErrorOccured = true;
                    return;
                }

                _outputPort.Standard(new GetExchangeRatesOutput(latestRates));
                _logger.LogInformation("GetExchangeRatesUseCase executed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in the GetExchangeRatesUseCase: {ex.Message}", ex.StackTrace);
                _outputPort.Error($"An error occurred in the GetExchangeRatesUseCase: {ex.Message}");
            }
        }
    }
}
