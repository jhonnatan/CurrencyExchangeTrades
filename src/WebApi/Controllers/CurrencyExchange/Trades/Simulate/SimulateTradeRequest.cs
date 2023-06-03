using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.CurrencyExchange.Trades.Simulate
{
    public class SimulateTradeRequest
    {
        [Required]
        [RegularExpression("EUR", ErrorMessage = "CurrencyFrom must be 'EUR'. Limited License")]
        public string CurrencyFrom { get; set; }
        [Required]
        public string CurrencyTo { get; set; }
        [Required]
        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "Amout must be greater than 0")]
        public decimal Amount { get; set; }
    }
}