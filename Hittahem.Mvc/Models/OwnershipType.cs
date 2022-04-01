using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hittahem.Mvc.Models
{
    public class OwnershipType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [InverseProperty("OwnershipType")]
        public List<Home> Homes { get; set; }

        public OwnershipType()
        {
            Homes = new List<Home>();
        }
    }
}
