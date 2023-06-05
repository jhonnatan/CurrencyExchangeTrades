using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers.CurrencyExchange.Trades.CreateTrade
{
    public class CreateCurrencyExchangeTradeRequest
    {
        [Required]
        public Client Client { get; set; }
        [Required]
        [RegularExpression("EUR", ErrorMessage = "CurrencyFrom must be 'EUR'. Limited License")]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "Amout must be greater than 0")]
        public decimal Amount { get; set; }        
    }

    public class Client
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string AccountId { get; set; }
        [Required]
        public string DestinationAccountId { get; set; }
    }
}