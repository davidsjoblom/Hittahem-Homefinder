using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hittahem.Mvc.Models
{
    public class HomeImage
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "image")]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }
        public string? Caption { get; set; }

        public int HomeId { get; set; }
        [ForeignKey("HomeId")]
        [InverseProperty("HomeImages")]
        public virtual Home? Home { get; set; }
    }
}
