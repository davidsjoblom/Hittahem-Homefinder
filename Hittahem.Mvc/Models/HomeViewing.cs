using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hittahem.Mvc.Models
{
    public class HomeViewing
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int HomeId { get; set; }
        public virtual Home? Home { get; set; }
    }
}
