using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            _logger.LogWarning("PRIVACY");
                        
           string user =
                User.Identity.IsAuthenticated ? User.Identity.Name : "nepøihlášený";

            ViewData["user"] = user;

            var privacyPolicy = _db.PrivacyPolicies.OrderByDescending(x => x.ValidFrom).FirstOrDefault();

            if (privacyPolicy is null)
            {
                privacyPolicy = new PrivacyPolicy()
                {
                    ValidFrom = new DateOnly(2024, 1, 1),
                    Text = "default"
                };
            }

            return View(privacyPolicy); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
