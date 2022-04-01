using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hittahem.Mvc.Models
{
    public class Street
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [InverseProperty("Street")]
        public virtual List<Home> Homes { get; set; }

        public Street()
        {
            Homes = new List<Home>();
        }
    }
}
