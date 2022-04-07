using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hittahem.Mvc.Enums;

namespace Hittahem.Mvc.Models
{
    public class Home
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int? Rooms { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? LivingArea { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? UninhabitableArea { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? GardenArea { get; set; }
        public int? BuildYear { get; set; }
        public DateTime? TimePosted { get; set; }
        public string? Adress { get; set; } //format t.ex: "kommun område gata gatunummer"
        public HousingType HousingType { get; set; }
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
