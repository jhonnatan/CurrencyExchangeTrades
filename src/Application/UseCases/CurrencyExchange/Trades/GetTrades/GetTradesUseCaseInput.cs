namespace Application.UseCases.CurrencyExchange.Trades.GetTrades
{
    public class GetTradesUseCaseInput
    {
        public Guid ClientId { get; private set; }

        public GetTradesUseCaseInput(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
