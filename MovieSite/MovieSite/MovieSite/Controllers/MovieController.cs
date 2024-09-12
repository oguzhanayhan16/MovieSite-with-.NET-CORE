using BusinessLayer.Concrate;
using DataAccesLayer.EntitiyFramework;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieSite.Areas.Admin.Models;
using MovieSite.Models;

namespace MovieSite.Controllers
{
    [AllowAnonymous]
    public class MovieController : Controller
    {

        private readonly ListConnectManager cm;
        private readonly ListManager lm;
        private readonly MovieManager mm;
        private readonly Context c;

        public MovieController()
        {
            cm = new ListConnectManager(new EFListConnectRepository());
            lm = new ListManager(new EFListCRepository());
            mm = new MovieManager(new EFMovieRepository());
            c = new Context();
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var listCItems = cm.GetList();
            var listItems = lm.GetList();
            var listID = listItems.Select(x => x.ListID).ToList();

            var values = lm.Take3GetList();

            var movies = mm.GetMoviesByListID(listID);
            var viewModel = new MovieListModel
            {
                ListC = values,
                Movies = movies,
                ListConnect = listCItems
            };
            return View(viewModel);
        }
       
        public PartialViewResult GetAllItems()
        {
            var listItems = lm.GetList();
            var listID = listItems.Select(x => x.ListID).ToList();
            var movies = mm.GetMoviesByListID(listID);

            var viewModel = new MovieListModel
            {
                ListC = listItems,
                Movies = movies,
                ListConnect = cm.GetList()
            };

            return PartialView("_MoreItems", viewModel);
        }

        [Authorize]
        public PartialViewResult GetAllItemsLog(int userID)
        {

            var listItems = lm.GetList();
            var listID = listItems.Select(x => x.ListID).ToList();
            var movies = mm.GetMoviesByListID(listID);

            var viewModel = new MovieListModel
            {
                ListC = listItems,
                Movies = movies,
                ListConnect = cm.GetList(),
                userID = userID

            };

            return PartialView("_MoreItemss", viewModel); 
        }

        [Authorize]
        public IActionResult LogMovie(int id)
        {
            var email = User.Identity.Name;
            var values = lm.Take3GetList();
            var userID = c.Users.FirstOrDefault(x => x.Email == email)?.UserID;
            ViewBag.v = userID;
            var listCItems = cm.GetList();
            var listItems = lm.GetList();
            var listID = listItems.Select(x => x.ListID).ToList();
            var movies = mm.GetMoviesByListID(listID);
            var userPaid = c.Users.Where(c => c.UserID == userID).Select(y => y.PaidUntilDate).FirstOrDefault();
            var RoleID = c.Users.Where(c => c.UserID == userID).Select(y => y.RoleID).FirstOrDefault();
            var paid = true;
            if (userPaid == null || (userPaid.Value - DateTime.Now).Days >= 30)
            {
                paid = false;
            }

            var viewModel = new MovieListModel
            {
                ListC = values,
                Movies = movies,
                ListConnect = listCItems,
                userID = userID,
                userPaid = paid,
                roleID = RoleID
            };
            ViewBag.IsLogMovie = true;
            return View(viewModel);
        }
    }
}