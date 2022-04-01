using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hittahem.Mvc.Models
{
    public class Home
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
        public int Rooms { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? LivingArea { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? UninhabitableArea { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? GardenArea { get; set; }
        public DateTime? BuildYear { get; set; }
        public DateTime? TimePosted { get; set; }
        public string? StreetNr { get; set; }

        //Many-to-one relationships
        public int StreetId { get; set; }
        [ForeignKey("StreetId")]
        [InverseProperty("Homes")]
        public virtual Street? Street { get; set; }
       
        public int UserId { get; set; } //ansvarig mäklare
        [ForeignKey("UserId")]
        [InverseProperty("Homes")]
        public virtual ApplicationUser? User { get; set; }

        public int MunicipalityId { get; set; }
        [ForeignKey("MunicipalityId")]
        [InverseProperty("Homes")]
        public virtual Municipality? Municipality { get; set; }

        public int HousingTypeId { get; set; }
        [ForeignKey("HousingTypeId")]
        [InverseProperty("Homes")]
        public virtual HousingType? HousingType { get; set; }

        public int OwnershipTypeId { get; set; }
        [ForeignKey("OwnershipTypeId")]
        [InverseProperty("Homes")]
        public virtual OwnershipType? OwnershipType { get; set; }


        //One-to-many relationship
        [InverseProperty("Home")]
        public List<HomeImage> HomeImages { get; set; }
        [InverseProperty("Home")]
        public List<HomeViewing> HomeViewings { get; set; }

        public List<InterestedUser> InterestedUsers { get; set; }

        public Home()
        {
            HomeImages = new List<HomeImage>();
            HomeViewings = new List<HomeViewing>();
            InterestedUsers = new List<InterestedUser>();
        }

    }
}
