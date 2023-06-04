using Domain.CurrencyExchange;

namespace UnitTests.Builders.CurrencyExchange
{
    public class CurrencyExchangeTradeBuilder
    {
        public Guid Id;
        public Guid ClientId;
        public string AccountId;
        public string DestinationAccountId;
        public string From;
        public string To;
        public decimal Amount;
        public decimal Rate;
        public DateTime TransactionDate;
        public decimal ConvertedAmount;

        public static CurrencyExchangeTradeBuilder New()
        {
            return new CurrencyExchangeTradeBuilder()
            {
                Id = Guid.NewGuid(),
                ClientId = Guid.NewGuid(),
                AccountId = "123456ABC",
                DestinationAccountId = "567890XYZ",
                From = "EUR",
                To = "USD",
                Amount = 1000,
                Rate = 1.07M,
                TransactionDate = DateTime.UtcNow,
                ConvertedAmount = 1000 * 1.07M
            };
        }

        public CurrencyExchangeTradeBuilder WithId(Guid value)
        {
            Id = value;
            return this;
        }

        public CurrencyExchangeTradeBuilder WithClientId(Guid value)
        {
            ClientId = value;
            return this;
        }

        public CurrencyExchangeTradeBuilder WithAccountId(string value)
        {
            AccountId = value;
            return this;
        }

        public CurrencyExchangeTradeBuilder WithDestinationAccountId(string value)
        {
            DestinationAccountId = value;
            return this;
        }

        public CurrencyExchangeTradeBuilder WithFrom(string value)
        {
            From = value;
            return this;
        }

        public CurrencyExchangeTradeBuilder WithTo(string value)
        {
            To = value;
            return this;
        }

        public CurrencyExchangeTradeBuilder WithAmount(decimal value)
        {
            Amount = value;
            return this;
        }

        public CurrencyExchangeTradeBuilder WithRate(decimal value)
        {
            Rate = value;
            return this;
        }

        public CurrencyExchangeTradeBuilder WithTransactionDate(DateTime value)
        {
            TransactionDate = value;
            return this;
        }

        public CurrencyExchangeTradeBuilder WithConvertedAmount(decimal value)
        {
            ConvertedAmount = value;
            return this;
        }

        public CurrencyExchangeTrade Build()
            => new(Id,
                ClientId,
                AccountId,
                DestinationAccountId,
                From,
                To,
                Amount,
                Rate,
                TransactionDate,
                ConvertedAmount);        
    }
}
