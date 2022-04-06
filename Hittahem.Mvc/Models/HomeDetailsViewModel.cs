namespace Hittahem.Mvc.Models
{
    public record HomeDetailsViewModel
    (
        int Index,
        IList<Home> Homes,
        IList<Street> Streets,
        IList<ApplicationUser> Users,
        IList<Municipality> Municipalities,
        IList<OwnershipType> OwnershipTypes,
        IList<HomeViewing> HomeViewings
    //om det behövs mer data skriv det här bara
    );
}
