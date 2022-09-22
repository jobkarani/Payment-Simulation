using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Services
{
    public class TransactionsDTO
    
    {
    
        [Key]
    
        public int Id { get; set; }
    
        public DateTime dateCreated { get; set; }
    
        public string routeId { get; set; }
    
        public string? originatorConversationId { get; set; }

        public string? systemConversationId { get; set; }

        public float amount { get;  set; }
    
        public string? reference { get;  set; }
    
        public int channelType { get;  set; }
    
        public string? customerAccountNo { get;  set; }
    
        public string? name { get;  set; }
    
        public string? address { get;  set; }
    
        public string? phoneNumber { get;  set; }
    
        public string? idNumber { get;  set; }
    
        public string? emailAddress { get;  set; }
    
        public string? financialInstitution { get;  set; }
    
        public string? primaryAccountNumber { get;  set; }
    
        public string? systemTraceAuditNumber { get; set; }

        public string? statusDescription { get; set; }

        public string? trackingNumber { get; set; }

        public string RemitterName { get; set; }

        public string RemitterAddress { get; set; }

        public string RemitterFinancialInstitution { get; set; }

        public string RemitterPrimaryAccountNumber { get; set; }

        public string RemitterIdNumber { get; set; }

        public string RemitterPhoneNumber { get; set; }

        public string RecipientName { get; set; }

        public string RecipientAddress { get; set; }

        public string RecipientFinancialInstitution { get; set; }

        public string RecipientPrimaryAccountNumber { get; set; }

        public string RecipientIdNumber { get; set; }

        public string RecipientPhoneNumber { get; set; }

        public string RecipientEmailAddress { get; set; }

    
    }

}