namespace Payment_Simulation.Services
{
    public class TransactionOutcomeDTO
    {
        public string? id { get; set; }
        
        public double paymentAmount { get; set; }
        
        public double? feeAmount { get; set; }
        
        public string? trackingNumber { get; set; }
        
        public int transactionStatus { get; set; }
        
        public string? transactionStatusDescription { get; set; }
        
        public object? resultCode { get; set; }
        
        public object? resultCodeDescription { get; set; }
    
    }
}