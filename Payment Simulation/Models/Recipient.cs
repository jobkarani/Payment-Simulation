using System.ComponentModel.DataAnnotations;

namespace Payment_Simulation.Models
{
    public class Recipient: ValueObject
    {
        [Required]
        [StringLength(20)]
        public string name { get; private set; }
        [Required]
        public string address { get; private set; }
        [Required]
        [StringLength(40)]
        public string emailAddress { get; private set; }
        [Required]
        [StringLength(12)]
        public string phoneNumber { get; private set; }
        [Required]
        [StringLength(8)]
        public string idNumber { get; private set; }
        [Required]
        [StringLength(20)]
        public string financialInstitution { get; private set; }
        [Required]
        [StringLength(13)]
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
