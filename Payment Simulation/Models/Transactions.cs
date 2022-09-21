using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Models
{
    public class Transactions
    {
       
        [Key]
        
        public int Id { get; set; }

        [MaxLength(64)]

        public string routeId { get; set; }

        [MaxLength(64)]

        public  string? systemConversationId { get; set; }

        [Required]

        [MaxLength(64)]

        public string originatorConversationId { get; set; }

        [Required(ErrorMessage = "Amount is Required")]

        public float amount { get; set; }

        [MaxLength(64)]

        public string reference { get; set; }
        
        public int channelType { get; set; }

        [MaxLength(64)]

        public string? transactionStatusDescription { get; set; }

        [MaxLength(64)]

        public string? resultCodeDescription { get; set; }

        public double? feeAmount{ get; set; }

        [MaxLength(64)]

        // public string 
        public string? trackingNumber { get; set; }

        public virtual Remitter Remitter { get; set; }

        public virtual Recipient Recipient { get; set; }

        public Transactions() {}

        public Transactions(int Id, string routeId, string systemConversationId, string originatorConversationId, float amount, string reference, int channelType, Remitter Remitter, Recipient Recipient)
        {
            
            this.Id = Id;
            
            this.routeId = routeId;
            
            this.systemConversationId = systemConversationId;
            
            this.originatorConversationId = originatorConversationId;
            
            this.amount = amount;
            
            this.reference = reference;
            
            this.channelType = channelType;
            
            this.Remitter =  Remitter;
            
            this.Recipient = Recipient;
        
        }
    }
}
