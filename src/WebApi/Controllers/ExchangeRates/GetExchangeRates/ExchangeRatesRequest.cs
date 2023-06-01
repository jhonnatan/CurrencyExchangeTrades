using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.ExchangeRates.GetExchangeRate
{
    public class ExchangeRatesRequest
    {
        [Required]
        public string CurrencyFrom { get; set; }
        [Required]
        public List<string> CurrenciesTo { get; set; }
    }
}