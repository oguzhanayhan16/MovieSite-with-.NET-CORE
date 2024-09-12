using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MovieSite.Models;

namespace MovieSite.ViewComponents.Category
{
    public class Genre : ViewComponent
    {
        GenreManager genre = new GenreManager(new EFGenreRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userID = c.Users.FirstOrDefault(x => x.Email == userName)?.UserID;
            
            
            var values = genre.Take3GetList();
            var model = new MovieListModel
            {
                userID = userID,
                genres=values
            };
            return View(model);
        }
    }
}
