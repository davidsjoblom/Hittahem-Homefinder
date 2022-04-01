using Hittahem.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hittahem.Mvc.Data;


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

        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel( 
                Homes: db.Homes.ToList(),
                Streets: db.Streets.ToList(),
                Users: db.Users.ToList(),
                Municipalities: db.Municipalities.ToList(),
                OwnershipTypes: db.OwnershipTypes.ToList(),
                HomeViewings: db.HomeViewings.ToList()
                );
            return View(model);
        }

        public IActionResult Details(int i)
        {
            var model = new HomeDetailsViewModel(
                index: i,
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