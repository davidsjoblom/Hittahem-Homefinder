namespace Hittahem.Mvc.Models
    
{
    public record HomeIndexViewModel
    (
        IList<Home> Homes,
        IList<ApplicationUser> Users,
        IList<HomeViewing> HomeViewings
    );
}
