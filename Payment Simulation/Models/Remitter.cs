using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Models
{
    public class Remitter: ValueObject
    {
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(64)]
        public string name { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        [MaxLength(64)]
        public string address { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [MaxLength(28)]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "ID Number is Required")]
        [MaxLength(28)]
        public string idNumber { get; set; }
        public string financialInstitution { get; set; }
        [Required(ErrorMessage = "Account Number is Required")]
        [MaxLength(28)]
        public string primaryAccountNumber { get; set; }

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
