namespace Payment_Simulation.Models
{
    public class Recipient: ValueObject
    {
        public string name { get; private set; }
        public string address { get; private set; }
        public string emailAddress { get; private set; }
        public string phoneNumber { get; private set; }
        public string idNumber { get; private set; }
        public string financialInstitution { get; private set; }
        public string primaryAccountNumber { get; private set; }

        public Recipient() { }

        public Recipient(string name, string address, string emailAddress, string phoneNumber, string idNumber, string financialInstitution, string primaryAccountNumber)
        {
            this.name = name;
            this.address = address;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.idNumber = idNumber;
            this.financialInstitution = financialInstitution;
            this.primaryAccountNumber = primaryAccountNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return name;
            yield return address;
            yield return emailAddress;
            yield return phoneNumber;
            yield return idNumber;
            yield return financialInstitution;
            yield return primaryAccountNumber;
        }
    }
}
