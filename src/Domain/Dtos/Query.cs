namespace Domain.Dtos
{
    public class Query
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public decimal Amount { get; private set; }

        public Query(string from, string to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
