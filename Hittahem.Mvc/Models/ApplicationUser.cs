using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hittahem.Mvc.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual List<Home> Homes { get; set; } // objekt mäklaren ansvarar för
        public List<InterestedUser> InterestedUsers { get; set; } //intresseanmälningar

        public ApplicationUser()
        {
            Homes = new List<Home>();
            InterestedUsers = new List<InterestedUser>();
        }
    }
}
