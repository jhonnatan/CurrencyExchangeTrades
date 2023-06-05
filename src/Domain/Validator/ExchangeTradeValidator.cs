using Domain.CurrencyExchange;
using FluentValidation;

namespace Domain.Validator
{
    public class ExchangeTradeValidator : AbstractValidator<CurrencyExchangeTrade>
    {
        public ExchangeTradeValidator()
        {
            RuleFor(r => r.Id)
                .NotNull()
                .NotEqual(new Guid())
                .WithMessage("A valid Id is required");
            RuleFor(r => r.ClientId)
                .NotNull()
                .NotEqual(new Guid())
                .WithMessage("A valid ClientId is required");
            RuleFor(r => r.AccountId)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("A valid AccountId is required");
            RuleFor(r => r.DestinationAccountId)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("A valid DestinationAccountId is required");
            RuleFor(r => r.From)
                .NotNull()
                .NotEmpty()
                .MaximumLength(3)
                .WithMessage("A valid CurrencyFrom is required");
            RuleFor(r => r.To)
                .NotNull()
                .NotEmpty()
                .MaximumLength(3)
                .WithMessage("A valid CurrencyTo is required");
            RuleFor(r => r.Amount)
                .GreaterThan(0)
                .WithMessage("The Amount must be greater than 0");
            RuleFor(r => r.TransactionDate)
                .NotNull()
                .NotEqual(new DateTime())
                .WithMessage("A valid TransactionDate is required");
            RuleFor(r => r.Rate)
                .GreaterThan(0)
                .WithMessage("The Rate must be greater than 0");
            RuleFor(r => r.ConvertedAmount)
                .GreaterThan(0)
                .WithMessage("The ConvertedAmount must be greater than 0");
        }
    }
}
