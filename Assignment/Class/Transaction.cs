using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Class
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        [Column(TypeName = "varchar(255)")]
       
        public string BankName { get; set; }
        public string Reference { get; set; }
        public DateTime Timestamp { get; set; }
        public string Location { get; set; }
    }
}
