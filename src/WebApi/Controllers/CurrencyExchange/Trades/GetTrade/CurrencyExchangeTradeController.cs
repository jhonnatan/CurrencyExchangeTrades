﻿using Application.UseCases.CurrencyExchange.Trades.GetTrade;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.CurrencyExchange.Trades.GetTrade
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExchangeTradeController : ControllerBase
    {
        private readonly ILogger<CurrencyExchangeTradeController> _logger;
        private readonly GetCurrencyExchangeTradePresenter _presenter;
        private readonly IGetTradeUseCase _getTradeUseCase;

        public CurrencyExchangeTradeController(ILogger<CurrencyExchangeTradeController> logger,
            GetCurrencyExchangeTradePresenter presenter,
            IGetTradeUseCase getTradeUseCase)
        {
            this._logger = logger;
            this._presenter = presenter;
            this._getTradeUseCase = getTradeUseCase;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(CurrencyExchangeTradesResponse), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get a currency exchange trade by id",
            Description = "Get a currency exchange trade by id")]
        public async Task<IActionResult> GetTrade([FromQuery][Required] Guid id)
        {
            _logger.LogInformation($"GetCurrencyExchangeTradeById Requested at {DateTime.UtcNow}");
            await _getTradeUseCase.Execute(new GetTradeUseCaseInput(id));
            return _presenter.ViewModel;
        }       
    }
}
