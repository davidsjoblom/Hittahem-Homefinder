using Hittahem.Mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace Hittahem.Mvc.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //if(context.Homes.Any())
                //{
                //    return;
                //}
                context.Homes.AddRange(
                    new Home
                    {
                        Price = 10000000,
                        Description = "Fint och trevligt hem",
                        Rooms = 3,
                        LivingArea = 55,
                        UninhabitableArea = 23,
                        GardenArea = 1230,
                        BuildYear = 1952,
                        Address = "Stockholmsvägen 3",
                        HousingType = Enums.HousingType.Villa,
                        OwnershipType = Enums.OwnershipType.Bostadsrätt,
                        Image = "/images/husbild.jpg"


                    }) ;
                context.SaveChanges();
            }
        }
    }
}
