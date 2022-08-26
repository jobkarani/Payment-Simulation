namespace Payment_Simulation.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public Guid originatorConversationId { get; set; }
        public float amount { get; private set; }
        public string? reference { get; private set; }
        public int channelType { get; private set; }
        public int customerAccountNo { get; private set; }

        public virtual Remitter Remitter { get; set; }

        public virtual Recipient Recipient { get; set; }
    }
}
