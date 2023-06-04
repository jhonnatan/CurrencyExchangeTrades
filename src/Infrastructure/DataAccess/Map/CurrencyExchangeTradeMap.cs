using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Map
{
    public class CurrencyExchangeTradeMap : IEntityTypeConfiguration<Entities.CurrencyExchangeTrade>
    {
        public void Configure(EntityTypeBuilder<Entities.CurrencyExchangeTrade> builder)
        {
            builder.ToTable("CurrencyExchangeTrades", "CurrencyExchange");
            builder.HasKey(k => k.Id);            
            builder.Property(p => p.ClientId).IsRequired();
            builder.Property(p => p.AccountId).IsRequired();
            builder.Property(p => p.DestinationAccountId).IsRequired();
            builder.Property(p => p.CurrencyFrom).IsRequired().HasMaxLength(3);
            builder.Property(p => p.CurrencyTo).IsRequired().HasMaxLength(3);
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Rate).IsRequired();
            builder.Property(p => p.TransactionDate).IsRequired();
            builder.Property(p => p.ConvertedAmount).IsRequired();
        }
    }
}
