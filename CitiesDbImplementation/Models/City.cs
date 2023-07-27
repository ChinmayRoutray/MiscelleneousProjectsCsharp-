using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitiesDbImplementation.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "nvarchar(20)")]
        public string? CityName { get; set; }

        [Required(ErrorMessage ="Capital name is required")]
        [Column(TypeName = "nvarchar(20)")]
        public string? CityCapital { get; set; }

        public ICollection<Interest> Interests { get; set; } = new List<Interest>();

        public City(/* string name, string capName*/)
        {
            /*CityName = name;
            CityCapital = capName;*/
        }
    }
}
