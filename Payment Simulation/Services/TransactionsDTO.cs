namespace Payment_Simulation.Services
{
    public class TransactionsDTO
    {
        public int Id { get; set; }
        public string? originatorConversationId { get; set; }
        public float amount { get; private set; }
        public string? reference { get; private set; }
        public int channelType { get; private set; }
        public string? customerAccountNo { get; private set; }
        public string name { get; private set; }
        public string address { get; private set; }
        public string phoneNumber { get; private set; }
        public string idNumber { get; private set; }
        public string emailAddress { get; private set; }
        public string financialInstitution { get; private set; }
        public string primaryAccountNumber { get; private set; }
    }
}
