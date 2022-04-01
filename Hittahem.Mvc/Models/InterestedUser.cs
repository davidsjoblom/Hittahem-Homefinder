namespace Hittahem.Mvc.Models
{
    public class InterestedUser
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public int HomeId { get; set; }
        public Home Home { get; set; } = null!;
    }
}
