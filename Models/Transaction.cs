using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankTransactions.Models
{
    public class Transaction : Base
    {
       public int TransactionId { get; set; }

        [DisplayName("Bank Name")]
        [Required]
        public string BankName { get; set; }

        [DisplayName("Beneficiary Name")]
        [Required]
        public string BeneficiaryName { get; set; }

        [DisplayName("Account Number")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only")]
        [Required]
        public string AccountNumber { get; set; }

        [DisplayName("Swift Code")]
        [MaxLength(12, ErrorMessage = "Maximum 11 characters only")]
        [Required]
        public string  SwiftCode { get; set; }

        [DisplayName("Amount")]
        [Required]
        public int Amount { get; set; }
    }
}
