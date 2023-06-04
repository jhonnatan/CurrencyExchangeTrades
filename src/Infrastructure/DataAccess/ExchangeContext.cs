using Infrastructure.DataAccess.Entities;
using Infrastructure.DataAccess.Map;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DataAccess
{
    public class ExchangeContext : DbContext
    {
        public DbSet<CurrencyExchangeTrade> CurrencyExchangeTrades { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = Environment.GetEnvironmentVariable("DBCONN");

            if (conn != null)
            {
                optionsBuilder.UseNpgsql(conn, npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "CurrencyExchange");
                });
            }
            else
                optionsBuilder.UseInMemoryDatabase("CurrencyExchangeInMemory");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfiguration(new CurrencyExchangeTradeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
