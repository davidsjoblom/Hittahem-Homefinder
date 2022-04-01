using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hittahem.Mvc.Models
{
    public class HousingType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [InverseProperty("HousingType")]
        public List<Home> Homes { get; set; }

        public HousingType()
        {
            Homes = new List<Home>();
        }
    }
}
