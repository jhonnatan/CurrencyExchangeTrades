namespace Domain.Dtos
{
    public class CreateExchangeTradeResponse
    {
        public Query Query { get; private set; }
        public Guid Id { get; private set; }
        public decimal Rate { get; private set; }
        public DateTime ExchangeTradeDate { get; private set; }
        public decimal ConvertedAmount { get; private set; }

        public CreateExchangeTradeResponse(Query query, Guid id, decimal rate, DateTime exchangeTradeDate, decimal convertedAmount)
        {
            Query = query;
            Id = id;
            Rate = rate;
            ExchangeTradeDate = exchangeTradeDate;
            ConvertedAmount = convertedAmount;
        }
    }
}
