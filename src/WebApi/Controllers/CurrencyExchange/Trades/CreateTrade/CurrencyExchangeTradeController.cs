﻿using Application.UseCases.CurrencyExchange.Trades.CreateTrade;
using Domain.CurrencyExchange.Trades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers.CurrencyExchange.Trades.CreateTrade
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExchangeTradeController : ControllerBase
    {
        private readonly ILogger<CurrencyExchangeTradeController> _logger;
        private readonly ICreateTradeUseCase _createTradeUseCase;
        private readonly CreateCurrencyExchangeTradePresenter _presenter;

        public CurrencyExchangeTradeController(ILogger<CurrencyExchangeTradeController> logger,
            ICreateTradeUseCase createTradeUseCase,
            CreateCurrencyExchangeTradePresenter presenter)
        {
            this._logger = logger;
            this._createTradeUseCase = createTradeUseCase;
            this._presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateCurrencyExchangeTradeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromBody] CreateCurrencyExchangeTradeRequest request)
        {
            _logger.LogInformation($"Currency Exchange Trade Executed at {DateTime.UtcNow} - Request: {JsonConvert.SerializeObject(request)}");

            var model = new CurrencyExchangeTrade(
                request.ClientId,
                request.AccountId,
                request.DestinationAccountId,
                request.CurrencyFrom,
                request.CurrencyTo,
                request.Amount);
            
            await _createTradeUseCase.Execute(new CreateTradeUseCaseInput(model));
            return _presenter.ViewModel;
        }
    }
}
