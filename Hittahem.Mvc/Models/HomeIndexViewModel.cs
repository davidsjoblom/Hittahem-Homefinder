using Hittahem.Mvc.Data;

namespace Hittahem.Mvc.Models
    
{
    public record HomeIndexViewModel
    (
        IList<Home> Homes,
        IList<Street> Streets,
        IList<ApplicationUser> Users,
        IList<Municipality> Municipalities,
        IList<OwnershipType> OwnershipTypes,
        IList<HomeViewing> HomeViewings
    //om det behövs mer data skriv det här bara
    );
}
