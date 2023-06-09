﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.CurrencyExchange.Rates.GetExchangeRates
{
    public class GetCurrencyExchangeRatesRequest
    {
        [Required]
        [RegularExpression("EUR", ErrorMessage = "CurrencyFrom must be 'EUR'. Limited License")]
        public string CurrencyFrom { get; set; }
        [Required]
        public List<string> CurrenciesTo { get; set; }
    }
}