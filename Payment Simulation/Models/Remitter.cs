namespace Payment_Simulation.Models
{
    public class Remitter: ValueObject
    {
        public string name { get; private set; }
        public string address { get; private set; }
        public string phoneNumber { get; private set; }
        public int idNumber { get; private set; }

        public Remitter() { }

        public Remitter(string name, string address, string phoneNumber, int idNumber)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.idNumber = idNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return name;
            yield return address;
            yield return phoneNumber;
        }
    }
}
