namespace Payment_Simulation.Services
{
    public class PaymentRequestDTO
    {
        public string originatorConversationId { get; set; }
        public string paymentNotes { get; set; }
        public List<Paymentorderline> paymentOrderLines { get; set; }
    }

    public class Paymentorderline
    {
        public RemitterDetails remitter { get; set; }
        public RecipientItem recipient { get; set; }
        public TransactionItem transaction { get; set; }
    }
    public class RecipientItem
    {
        public string name { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string idType { get; set; }
        public string idNumber { get; set; }
        public string financialInstitution { get; set; }
        public string primaryAccountNumber { get; set; }
        public string mccmnc { get; set; }
        public int ccy { get; set; }
        public string country { get; set; }
        public string purpose { get; set; }
    }

    public class RemitterDetails
    {
        public string name { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string idType { get; set; }
        public string idNumber { get; set; }
        public string financialInstitution { get; set; }
        public string primaryAccountNumber { get; set; }
        public string mccmnc { get; set; }
        public int ccy { get; set; }
        public string country { get; set; }
        public string purpose { get; set; }
    }

    public class TransactionItem
    {
        public string routeId { get; set; }
        public int ChannelType { get; set; }
        public int amount { get; set; }
        public string reference { get; set; }
        public string systemTraceAuditNumber { get; set; }
    }
}
