using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cities.Models
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int InterestId { get; set; }

        [Required(ErrorMessage = "Please describe the city attractions.")]
        public string? Description { get; set; }

        [ForeignKey("CityId")] 
        public virtual int CityId  { get; set; }

        public Interest(int interestId, string? description, int cityId)
        {
            InterestId = interestId;
            Description = description;
            CityId = cityId;
        }
    }
}
