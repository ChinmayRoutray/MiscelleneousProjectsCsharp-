using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cities.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        [Required(ErrorMessage ="Please, City name")]
        public string CityName { get; set; }
        [Required (ErrorMessage = "Please, City capital")]
        public string CityCapital { get; set; }
        public List<Interest> AllInterests { get; set; } = new List<Interest>();

        public City(int id, string name, string capital, List<Interest> inter)
        {
            CityId = id;
            CityName = name;
            CityCapital = capital;
            AllInterests = inter;
        }
    }
}
