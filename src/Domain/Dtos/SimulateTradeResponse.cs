namespace Domain.Dtos
{
    public class SimulateTradeResponse
    {
        public Query Query { get; set; }
        public decimal Rate { get; set; }
        public DateTime SimulationDate { get; set; }
        public decimal ConvertedAmount { get; set; }

        public SimulateTradeResponse(Query query, decimal rate, DateTime simulationDate, decimal convertedAmount)
        {
            Query = query;
            Rate = rate;
            SimulationDate = simulationDate;
            ConvertedAmount = convertedAmount;
        }
    }
    
}
