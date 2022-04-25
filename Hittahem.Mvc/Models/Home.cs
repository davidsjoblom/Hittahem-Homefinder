using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hittahem.Mvc.Enums;

namespace Hittahem.Mvc.Models
{
    public class Home
    {
        public int Id { get; set; }

        [Display(Name = "Pris")]
        public int Price { get; set; }
        [Display(Name = "Beskrivning")]

        [MaxLength(100)]
        public string? Description { get; set; }
        [Display(Name = "Rum")]
        public int? Rooms { get; set; }
        [Display(Name = "Boarea")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? LivingArea { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Biarea")]
        public decimal? UninhabitableArea { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Tomtarea")]
        public decimal? GardenArea { get; set; }
        [Display(Name = "Byggår")]
        public int? BuildYear { get; set; }

        [Display(Name ="Annons datom och tid")]
        public DateTime? TimePosted { get; set; }
        public string? Adress { get; set; } //format t.ex: "kommun område gata gatunummer"
        [Display(Name = "Bostadstyp")]
        public HousingType HousingType { get; set; }
        [Display(Name = "Upplåtelseform")]
        public OwnershipType OwnershipType { get; set; }
        public string? Image { get; set; } //route till en bild


        public int AgentId { get; set; } //foreign key till ansvarig mäklare
        public virtual ApplicationUser? Agent { get; set; }


        //navigation properties
        public List<HomeViewing> HomeViewings { get; set; }
        public List<InterestedUser> InterestedUsers { get; set; }

        public Home()
        {
            HomeViewings = new List<HomeViewing>();
            InterestedUsers = new List<InterestedUser>();
        }
    }
}
