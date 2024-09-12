using Microsoft.AspNetCore.Mvc;

namespace MovieSite.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult Navbar()
        {
            return PartialView();
        }
        public PartialViewResult TopNavbar()
        {
            var userName = User.Identity.Name;
            return PartialView();
        }
    }
}
