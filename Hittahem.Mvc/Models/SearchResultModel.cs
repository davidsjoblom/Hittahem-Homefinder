using Hittahem.Mvc.Enums;

namespace Hittahem.Mvc.Models
{
    public class SearchResultModel
    {
        public List<Home> HouseResult { get; set; }
        public string SearchString { get; set; }

        public int[] HousingType { get; set; }

        public Area Area { get; set; }
        public Price Price { get; set; }
        public Room Room { get; set; }
    }


}
