using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Services
{
    public class TransactionsDTO
    
    {
    
        [Key]
    
        public int Id { get; set; }
    
        public DateTime TransactedOn { get; set; }
    
        public string routeId { get; set; }
    
        public string? originatorConversationId { get; set; }
    
        public float amount { get;  set; }
    
        public string? reference { get;  set; }
    
        public int channelType { get;  set; }
    
        public string? customerAccountNo { get;  set; }
    
        public string name { get;  set; }
    
        public string address { get;  set; }
    
        public string phoneNumber { get;  set; }
    
        public string idNumber { get;  set; }
    
        public string emailAddress { get;  set; }
    
        public string financialInstitution { get;  set; }
    
        public string primaryAccountNumber { get;  set; }
    
         public string systemTraceAuditNumber { get; set; }
    
    }

}