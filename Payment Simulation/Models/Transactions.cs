﻿using System.ComponentModel.DataAnnotations;

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
        public string? originatorConversationId { get; set; }

        [Required(ErrorMessage = "Amount is Required")]
        public float amount { get; set; }

        [MaxLength(64)]
        public string reference { get; set; }
        
        public int channelType { get; set; }

        public virtual Remitter Remitter { get; set; }

        public virtual Recipient Recipient { get; set; }
    }
}
