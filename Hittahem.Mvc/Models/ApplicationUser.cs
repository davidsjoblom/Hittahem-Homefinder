using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hittahem.Mvc.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [InverseProperty("User")]
        public virtual List<Home> Homes { get; set; }
        public List<InterestedUser> InterestedUsers { get; set; }

        public ApplicationUser()
        {
            Homes = new List<Home>();
            InterestedUsers = new List<InterestedUser>();
        }
    }
}
