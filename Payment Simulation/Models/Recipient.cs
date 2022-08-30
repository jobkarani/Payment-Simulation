using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Models
{
    public class Recipient: ValueObject
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(20)]
        public string name { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string address { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [StringLength(40)]
        public string emailAddress { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [StringLength(12)]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "ID Number is Required")]
        [StringLength(8)]
        public string idNumber { get; set; }
        [Required(ErrorMessage = "Bank is Required")]
        [StringLength(20)]
        public string financialInstitution { get; set; }
        [Required(ErrorMessage = "Account Number is Required")]
        [StringLength(13)]
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
