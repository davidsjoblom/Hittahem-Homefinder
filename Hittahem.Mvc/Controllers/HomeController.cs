using Hittahem.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hittahem.Mvc.Data;
using Hittahem.Mvc.Enums;

namespace Hittahem.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext injectedContext)
        {
            db = injectedContext;
        }

        public IActionResult Index(SearchResultModel searchResult = null)
        {
            HomeIndexViewModel model = new();
            if (searchResult == null)
            {
                model = new() 
                {
                    Homes = db.Homes.ToList()
                    //Streets: db.Streets.ToList(),
                    //Users: db.Users.ToList(),
                    //Municipalities: db.Municipalities.ToList(),
                    //OwnershipTypes: db.OwnershipTypes.ToList(),
                    /*HomeViewings: db.HomeViewings.ToList()*/
                }; 
            }
            else
            {
                model = new()
                {
                    Homes = searchResult.HouseResult
                };
            }
           
            return View(model);
        }

        public IActionResult Search([FromForm] SearchResultModel model)
        {
            //Leta efter result med hjälp av dom parameterar som kommer med model.
            //1. Kolla först i databasen om det finns en kommun som passa med SearchString värdet
            //OM den har ett värde annars hämta allt.
            var homes = db.Homes.Select(h => h);
            
            if (!string.IsNullOrEmpty(model.SearchString))
            {
                homes = homes.Where(h => h.Adress.Contains(model.SearchString));
            }       
            
            //3. Ta endast Home som uppfyller detta krav på Area.
            //Switch på enumen
            switch (model.Area)
            {
                case Enums.Area.None:
                    break;
                case Enums.Area.Smallest:
                    homes = homes.Where(h => h.LivingArea <= 30m);
                    break;
                case Enums.Area.Smaller:
                    homes = homes.Where(h => h.LivingArea <= 60m);
                    break;
                case Enums.Area.Small:
                    homes = homes.Where(h => h.LivingArea <= 80m);
                    break;
                case Enums.Area.Big:
                    homes = homes.Where(h => h.LivingArea <= 120m);
                    break;
                case Enums.Area.Bigger:
                    homes = homes.Where(h => h.LivingArea <= 150m);
                    break;
                default:
                    break;
            }

            //4. Ta endast Home som uppfyller detta krav på Price
            switch (model.Price)
            {
                case Enums.Price.None:
                    break;
                case Enums.Price.Start:
                    homes = homes.Where(h => h.Price >= 50000);
                    break;
                case Enums.Price.Second:
                    homes = homes.Where(h => h.Price >= 100000);
                    break;
                case Enums.Price.Middle:
                    homes = homes.Where(h => h.Price >= 500000);
                    break;
                case Enums.Price.Large:
                    homes = homes.Where(h => h.Price >= 1000000);
                    break;
                case Enums.Price.Larger:
                    homes = homes.Where(h => h.Price >= 5000000);
                    break;
                case Enums.Price.Castle:
                    homes = homes.Where(h => h.Price >= 10000000);
                    break;
                case Enums.Price.More:
                    homes = homes.Where(h => h.Price <= 10000000);
                    break;
                default:
                    break;
            }

            //5. Ta endast Home som uppfyller detta krav på Room.

            switch (model.Room)
            {
                case Enums.Room.None:
                    break;
                case Enums.Room.One:
                    homes = homes.Where(h => h.Rooms == 1);
                    break;
                case Enums.Room.Two:
                    homes = homes.Where(h => h.Rooms == 2);
                    break;
                case Enums.Room.Three:
                    homes = homes.Where(h => h.Rooms == 3);
                    break;
                case Enums.Room.Four:
                    homes = homes.Where(h => h.Rooms == 4);
                    break;
                case Enums.Room.Five:
                    homes = homes.Where(h => h.Rooms == 5);
                    break;
                case Enums.Room.Six:
                    homes = homes.Where(h => h.Rooms == 6);
                    break;
                case Enums.Room.Above:
                    homes = homes.Where(h => h.Rooms <= 7);
                    break;
                default:
                    break;
            }

            //2. Ta endast dom HousingTypes i Home som användaren har valt.
            //Tips på metod Where(), appliceras på en lista.
            List<Home> filterList = new();
            if (model.HousingType.Any())
            {                
                foreach (var type in model.HousingType)
                {
                    filterList.AddRange(homes.Where(h => h.HousingType.Equals(Enum.Parse(typeof(HousingType), type.ToString()))));
                }
            }

            //Resultat av all filtering och sökning ska senare läggas i variabeln model.HouseResult
            var homesToList = homes.ToList();
            if (filterList.Any())
            {
                homesToList = filterList;
            }

            model.HouseResult = homesToList;

            //Skicka med husen som matchar sökningen tillbaka till Index.
            return RedirectToAction("Index", model);
        }

        public IActionResult Details(int i)
        {
            var model = new HomeDetailsViewModel(
                Index: i,
                Homes: db.Homes.ToList(),
                //Streets: db.Streets.ToList(),
                Users: db.Users.ToList(),
                //Municipalities: db.Municipalities.ToList(),
                //OwnershipTypes: db.OwnershipTypes.ToList(),
                HomeViewings: db.HomeViewings.ToList()
                );
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}