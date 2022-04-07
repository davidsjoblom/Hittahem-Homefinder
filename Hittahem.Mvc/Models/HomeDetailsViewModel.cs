namespace Hittahem.Mvc.Models
{
    public record HomeDetailsViewModel
    (
        int Index,
        IList<Home> Homes,
        IList<ApplicationUser> Users,
        IList<HomeViewing> HomeViewings
    );
}
