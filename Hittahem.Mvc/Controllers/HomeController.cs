using Hittahem.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hittahem.Mvc.Data;


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
            //HousingType är nu en int som ska paras ihop med rätt enum.
            //Room, Area och price blir alltid filtrerad på första värdet i option. Första måste vara tomt.


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