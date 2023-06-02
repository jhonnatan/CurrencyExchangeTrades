using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.ExchangeRates.GetExchangeRate
{
    public class ExchangeRatesRequest
    {
        [Required]
        [RegularExpression("EUR", ErrorMessage = "CurrencyFrom must be 'EUR'. Limited License")]
        public string CurrencyFrom { get; set; }
        [Required]
        public List<string> CurrenciesTo { get; set; }
    }
}