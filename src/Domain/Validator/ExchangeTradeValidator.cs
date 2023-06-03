using Domain.CurrencyExchange.Trades;
using FluentValidation;

namespace Domain.Validator
{
    public class ExchangeTradeValidator : AbstractValidator<CurrencyExchangeTrade>
    {
        public ExchangeTradeValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEqual(new Guid()).WithMessage("A valid Id is required");
            RuleFor(r => r.ClientId).NotNull().NotEqual(new Guid()).WithMessage("A valid ClientId is required");
            RuleFor(r => r.AccountId).NotNull().NotEqual(new Guid()).WithMessage("A valid AccountId is required");
            RuleFor(r => r.DestinationAccountId).NotEqual(new Guid()).WithMessage("if informed, a valid DestinationAccountId is required");
            RuleFor(r => r.CurrencyFrom).NotNull().NotEmpty().WithMessage("A valid CurrencyFrom is required");
            RuleFor(r => r.CurrencyTo).NotNull().NotEmpty().WithMessage("A valid CurrencyTo is required");
            RuleFor(r => r.Amount).GreaterThan(0).WithMessage("The Amount must be greater than 0");
            RuleFor(r => r.TransactionDate).NotNull().NotEqual(new DateTime()).WithMessage("A valid TransactionDate is required");
        }
    }
}
