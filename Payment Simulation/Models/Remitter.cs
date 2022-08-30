using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Models
{
    public class Remitter: ValueObject
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(20)]
        public string name { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string address { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [StringLength(12)]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "ID Number is Required")]
        [StringLength(8)]
        public string idNumber { get; set; }

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
