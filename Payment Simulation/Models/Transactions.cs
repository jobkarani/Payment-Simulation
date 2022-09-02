using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Models
{
    public class Transactions
    {
        public int Id { get; set; }

        public string routeId { get; set; }

        [MaxLength(64)]
        public  string? systemConversationId { get; set; }
        [Required]
        [MaxLength(64)]
        public string? originatorConversationId { get; set; }

        [Required(ErrorMessage = "Amount is Required")]
        public float amount { get; set; }

        [MaxLength(64)]
        public string reference { get; set; }
        
        public int channelType { get; set; }
        [Required(ErrorMessage = "Account Number is Required")]
        [MaxLength(28)]

        public virtual Remitter Remitter { get; set; }

        public virtual Recipient Recipient { get; set; }
    }
}
