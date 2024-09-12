using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MovieSite.ViewComponents.NavbarName
{
    public class NavbarName : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;


            var userID = c.Users.FirstOrDefault(x => x.Email == userName)?.UserID;
            var name = c.Users.FirstOrDefault(x => x.Email == userName)?.FirstName;
            var lastName = c.Users.FirstOrDefault(x => x.Email == userName)?.LastName;
            var avatar = c.Users.FirstOrDefault(x => x.Email == userName)?.Avatar;
   

            ViewBag.v1 = name;
            ViewBag.v2 = lastName;
            ViewBag.v3 = avatar;
            ViewBag.v4 = userID;


            return View();
        }

    }
}
