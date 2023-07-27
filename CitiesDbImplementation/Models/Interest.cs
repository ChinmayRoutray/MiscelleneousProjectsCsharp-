using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitiesDbImplementation.Models
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int InterestId {get; set;}

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Main Attraction")]
        public string Description { get; set;}

        [ForeignKey("CityId")]
        //public City? City { get; set;}
        public int CityId { get; set;}

        public Interest(/*string desc*/)
        {
           /* this.Description = desc;*/
        }
    }
}
