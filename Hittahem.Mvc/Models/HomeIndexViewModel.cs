namespace Hittahem.Mvc.Models

{
    public class HomeIndexViewModel
    {
        public IEnumerable<Home>? SearchResultHomes { get; set; }
        public IEnumerable<Street>? Streets { get; set; }
        public IEnumerable<Municipality>? Municipalities { get; set; }
        public IEnumerable<OwnershipType>? OwnershipTypes { get; set; }
        public IEnumerable<HousingType>? HousingTypes { get; set;}
    }
}
