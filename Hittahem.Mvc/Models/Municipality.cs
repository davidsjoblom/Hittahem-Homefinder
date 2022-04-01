using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hittahem.Mvc.Models
{
    public class Municipality
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [InverseProperty("Municipality")]
        public virtual List<Home> Homes { get; set; }

        public Municipality()
        {
            Homes = new List<Home>();
        }
    }
}
