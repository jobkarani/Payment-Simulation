using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Models
{
    public class Recipient: ValueObject
    {
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(128)]
        public string name { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        [MaxLength(128)]
        public string address { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [MaxLength(64)]
        public string emailAddress { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [MaxLength(64)]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "ID Number is Required")]
        [MaxLength(28)]
        public string idNumber { get; set; }
        [Required(ErrorMessage = "Bank is Required")]
        [MaxLength(64)]
        public string financialInstitution { get; set; }
        [Required(ErrorMessage = "Account Number is Required")]
        [MaxLength(28)]
        public string primaryAccountNumber { get; set; }

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
