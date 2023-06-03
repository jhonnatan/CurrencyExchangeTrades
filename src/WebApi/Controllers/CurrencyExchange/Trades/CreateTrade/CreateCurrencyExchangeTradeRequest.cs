using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.CurrencyExchange.Trades.CreateTrade
{
    public class CreateCurrencyExchangeTradeRequest
    {
        [Required]
        public Guid ClientId { get; set; }
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        public Guid DestinationAccountId { get; set; }
        [Required]
        public string CurrencyFrom { get; set; }
        [Required]
        public string CurrencyTo { get; set; }
        [Required]
        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "Amout must be greater than 0")]
        public decimal Amount { get; set; }        
    }
}