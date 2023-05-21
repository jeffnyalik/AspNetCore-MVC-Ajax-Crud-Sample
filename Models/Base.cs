using System.ComponentModel.DataAnnotations;

namespace BankTransactions.Models
{
    public class Base
    {
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime CreatedAt { get; set; } = DateTime.Today;

        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
