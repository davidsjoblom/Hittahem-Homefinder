using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hittahem.Mvc.Models
{
    public class HomeViewing
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int HomeId { get; set; }
        [ForeignKey("HomeId")]
        [InverseProperty("HomeViewings")]
        public virtual Home? Home { get; set; }
    }
}
