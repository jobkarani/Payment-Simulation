using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Models
{
    public class Remitter: ValueObject
    {
        [Required]
        [StringLength(20)]
        public string name { get; private set; }
        [Required]
        public string address { get; private set; }
        [Required]
        [StringLength(12)]
        public string phoneNumber { get; private set; }
        [Required]
        [StringLength(8)]
        public string idNumber { get; private set; }

        public Remitter() { }

        public Remitter(string name, string address, string phoneNumber, string idNumber)
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
