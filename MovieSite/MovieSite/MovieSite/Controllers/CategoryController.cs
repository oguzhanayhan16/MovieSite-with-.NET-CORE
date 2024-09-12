using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using MovieSite.Areas.Admin.Models;
using MovieSite.Models;
using MovieSite.ViewComponents.Category;

namespace MovieSite.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        GenreManager genre = new GenreManager(new EFGenreRepository());
        GenreConManager gm = new GenreConManager(new EFGenreConRepository());
        MovieManager mm = new MovieManager(new EFMovieRepository());
        Context c = new Context();
        public IActionResult GenrePage(int id,int userID, int page = 1)
        {
            var values = gm.GetListCategoryMovies(id);
            var gen = genre.GetListByID(id);
            var dizi = mm.GetMoviesByListIDforCategory(values);

            int pageSize = 15;
            var totalMovies = c.GenreCons.Where(m => m.GenreID == id).Count();


            var dizii = dizi.Skip((page - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();  // B

            var model = new MovieListModel()
            {
                userID = userID,
                Movies=dizii,
                TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize),
                CurrentPage = page,
                genre =gen
            };
            return View(model);

        }
        public IActionResult Genre(int userID)
        {
            var values = genre.GetList();
            var model = new MovieListModel()
            {
                userID = userID,
                genres = values
            };

            return View(model);

        }
        [HttpGet]
        public IActionResult AllMovie(int userID, int page = 1)
        {
         
            var values = mm.GetList();

            int pageSize = 15;
            var totalMovies = c.Movies.Count();


            var dizii = values.Skip((page - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();  // B

            var model = new MovieListModel()
            {
                userID = userID,
                Movies = dizii,
                TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize),
                CurrentPage = page,
                
            };
            return View(model);

        }

        [HttpGet]
        public IActionResult SearchMovies(string query)
        {
            var movies = c.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                movies = movies.Where(m => m.Name.Contains(query));
            }

            var result = movies.Select(m => new
            {
                m.MovieID,
                m.Name,
                m.Image
            }).ToList();

            return Json(result);
        }
     

    }
}
