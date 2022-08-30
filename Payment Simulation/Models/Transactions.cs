using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        [Required]
        [StringLength(16)]
        public string? originatorConversationId { get; set; }
        [Required(ErrorMessage = "Amount is Required")]
        public float amount { get; set; }
        public string? reference { get; set; }
        public int channelType { get; set; }
        [Required(ErrorMessage = "Account Number is Required")]
        [StringLength(16)]
        public string? customerAccountNo { get; set; }

        public virtual Remitter Remitter { get; set; }

        public virtual Recipient Recipient { get; set; }
    }
}
