using Microsoft.AspNetCore.Mvc;
using MVC.Data;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext db;

        public UsersController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult All()
        {
            List<Microsoft.AspNetCore.Identity.IdentityUser> users = db.Users.ToList();

            return View(users);
        }
    }
}
