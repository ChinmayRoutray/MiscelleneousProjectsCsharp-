using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_MVC_App.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "username")]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Password")]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(12)")]
        [Display(Name = " Account Number")]
        [MaxLength(12)]
        public string AccountNumber { get; set; }
        public int AccountBalance { get; set; }

        public User() { }
    }
}
