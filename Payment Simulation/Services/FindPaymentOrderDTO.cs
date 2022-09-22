namespace Payment_Simulation.Services
{
    public class FindPaymentOrderDTO
    {
        
            public string id { get; set; }
            public string conversationId { get; set; }
            public string originatorConversationId { get; set; }
            public string remarks { get; set; }
            public bool isProcessed { get; set; }
            public List<OrderLine> orderLines { get; set; }
    }
    public class OrderLine
    {
        public Remitters remitter { get; set; }
        public Recipients recipient { get; set; }
        public Transaction transaction { get; set; }
        public TransactionOutcome transactionOutcome { get; set; }
    }

    public class Recipients
    {
        public string name { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string mccmnc { get; set; }
        public string idType { get; set; }
        public string idNumber { get; set; }
        public string financialInstitution { get; set; }
        public object institutionIdentifier { get; set; }
        public string primaryAccountNumber { get; set; }
        public int ccy { get; set; }
        public string purpose { get; set; }
        public object country { get; set; }
    }

    public class Remitters
    {
        public object name { get; set; }
        public object address { get; set; }
        public string phoneNumber { get; set; }
        public object idType { get; set; }
        public object idIssuePlace { get; set; }
        public object idNumber { get; set; }
        public object idIssueDate { get; set; }
        public object idExpireDate { get; set; }
        public object nationality { get; set; }
        public object country { get; set; }
        public object ccy { get; set; }
        public object financialInstitution { get; set; }
        public object sourceOfFunds { get; set; }
        public object principalActivity { get; set; }
        public object dateOfBirth { get; set; }
    }



    public class ThirdPartyPayload
    {
        public object thirdPartyResultCode { get; set; }
        public object thirdPartyResultCodeDescription { get; set; }
        public object thirdPartyReceiptNumber { get; set; }
    }

    public class Transaction
    {
        public string routeId { get; set; }
        public double amount { get; set; }
        public string reference { get; set; }
        public string systemTraceAuditNumber { get; set; }
        public int type { get; set; }
        public int channelType { get; set; }
        public object customerAccountNo { get; set; }
        public string routeTransactionTypeId { get; set; }
    }

    public class TransactionOutcome
    {
        public string id { get; set; }
        public double paymentAmount { get; set; }
        public double feeAmount { get; set; }
        public string trackingNumber { get; set; }
        public int transactionStatus { get; set; }
        public string transactionStatusDescription { get; set; }
        public object resultCode { get; set; }
        public object resultCodeDescription { get; set; }
        public ThirdPartyPayload thirdPartyPayload { get; set; }
    }

}
