using Hittahem.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hittahem.Mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace Hittahem.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }
        /// <summary>
        /// Första medtoden som kallas när Index startar.
        /// Då vill vi fylla dropsdowns med det datan vi har 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(HomeIndexViewModel model = null)
        {
            if (model.HousingTypes is null)
            {
                model = new HomeIndexViewModel
                {
                    Streets = db.Streets.ToList(),
                    Municipalities = db.Municipalities.ToList(),
                    OwnershipTypes = db.OwnershipTypes.ToList(),
                    HousingTypes = db.HousingTypes.ToList(),
                    
                };
            }            

            return View(model);
        }

        /// <summary>
        /// Detta är metoden som vi skickar in alla parameters som vi vill söka med.
        /// Dvs värden från dropdown samt Ort sökfölt aka searchMunicipalityString
        /// </summary>
        /// <param name="searchMunicipalityString"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Search([FromForm] SearchFormModel searchModel)
        {
            var homes = db.Homes.ToList();

            var returnValue = homes.Where(h => h.Municipality != null && h.Municipality.Name.Contains(searchModel.SearchMunicipality));
                        

            HomeIndexViewModel indexViewModel = new HomeIndexViewModel
            {
                SearchResultHomes = returnValue,
                Streets = db.Streets.ToList(),
                Municipalities = db.Municipalities.ToList(),
                OwnershipTypes = db.OwnershipTypes.ToList()
                
            };

            return RedirectToAction("Index",indexViewModel);
        }

        //public IActionResult Index(string searchString)
        //{
        //    HomeIndexViewModel model = new HomeIndexViewModel( 
        //        Homes: db.Homes.ToList(),
        //        Streets: db.Streets.ToList(),
        //        Users: db.Users.ToList(),
        //        Municipalities: db.Municipalities.ToList(),
        //        OwnershipTypes: db.OwnershipTypes.ToList(),
        //        HomeViewings: db.HomeViewings.ToList()
        //        );

        //    return View(model);
        //}

        public IActionResult Details(int i)
        {
            var model = new HomeDetailsViewModel(
                Index: i,
                Homes: db.Homes.ToList(),
                Streets: db.Streets.ToList(),
                Users: db.Users.ToList(),
                Municipalities: db.Municipalities.ToList(),
                OwnershipTypes: db.OwnershipTypes.ToList(),
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