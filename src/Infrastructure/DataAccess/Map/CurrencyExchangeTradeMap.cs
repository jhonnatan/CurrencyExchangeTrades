using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.CurrencyExchange;

namespace Infrastructure.DataAccess.Map
{
    public class CurrencyExchangeTradeMap : IEntityTypeConfiguration<CurrencyExchangeTrade>
    {
        public void Configure(EntityTypeBuilder<CurrencyExchangeTrade> builder)
        {
            builder.ToTable("CurrencyExchangeTrades", "CurrencyExchange");
            builder.HasKey(k => k.Id);            
            builder.Property(p => p.ClientId).IsRequired();
            builder.Property(p => p.AccountId).IsRequired().HasMaxLength(100);
            builder.Property(p => p.DestinationAccountId).IsRequired().HasMaxLength(100); ;
            builder.Property(p => p.From).IsRequired().HasMaxLength(3);
            builder.Property(p => p.To).IsRequired().HasMaxLength(3);
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Rate).IsRequired();
            builder.Property(p => p.TransactionDate).IsRequired();
            builder.Property(p => p.ConvertedAmount).IsRequired();
            builder.Ignore(p => p.Invalid);
            builder.Ignore(p => p.Valid);
            builder.Ignore(p => p.ValidationResult);
        }
    }
}
