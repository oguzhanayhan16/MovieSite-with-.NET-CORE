using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieSite.Areas.Admin.Models;

namespace MovieSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class AdminCommentController : Controller
    {

        MovieManager mm = new MovieManager(new EFMovieRepository());
        CommentManager cm = new CommentManager(new EFCommentRepository());
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            var values = mm.GetList();
            int pageSize = 12;
            var totalMovies = c.Movies.Count();

            var dizii = values.Skip((page - 1) * pageSize)
                   .Take(pageSize)
                   .ToList();
            var movie = new CommentViewModel
            {
                movies = dizii,
                TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize),
                CurrentPage = page,
            };

            return View(movie);
        }


        [HttpGet]
        public IActionResult CommentPage(int movieID)
        {
            var values = cm.FindCommentUser(movieID);
            var comment = cm.GetCommentUser(values);
            var getcomment = cm.GetList(movieID);

            var model = new CommentViewModel
            {
                
                users=comment,
                comments=getcomment
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DelComment(int CommentID)
        {
            var userToDelete = c.Comments.FirstOrDefault(u => u.CommentID == CommentID);
            if (userToDelete == null)
            {
                return NotFound();
            }

            cm.TDelete(userToDelete);
            c.SaveChanges();

            return RedirectToAction("Index", "AdminComment");
        }

        [HttpPost]
        public IActionResult DelCommentUser(int CommentID)
        {
            var userToDelete = c.Comments.FirstOrDefault(u => u.CommentID == CommentID);
            if (userToDelete == null)
            {
                return NotFound();
            }

            cm.TDelete(userToDelete);
            c.SaveChanges();

            return RedirectToAction("Index", "Client");
        }

    }
}
