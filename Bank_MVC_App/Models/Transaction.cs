using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_MVC_App.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [MaxLength(20)]
        public string Benificiary { get; set; } = string.Empty;
        
        [Required]
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }

        public Transaction() { }
    }
}
