using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation;
using MovieSite.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;


namespace MovieSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class CategoryListController : Controller
    {
        GenreManager cm = new GenreManager(new EFGenreRepository());
        GenreConManager gm = new GenreConManager(new EFGenreConRepository());
        MovieManager mm = new MovieManager(new EFMovieRepository());
        Context c = new Context();
        public IActionResult Category()
        {

            var category = new CategoryViewModel
            {
                category = cm.GetList(),
            };

            return View(category);
        }

        [HttpGet]
        public IActionResult CategoryDetails(int id)
        {
            var values = c.Genres.Where(x=>x.GenreID == id).FirstOrDefault();

            var genre = new CategoryViewModel
            {

                genreID = id,
                genre=values

            };



            return View(genre);
        }
        [HttpPost]
        public IActionResult CategoryDetails(CategoryViewModel model)
        {
            var genreUpdate = c.Genres.FirstOrDefault(u => u.GenreID == model.genreID);
            if (genreUpdate == null)
            {
                return NotFound();
            }

            // Diğer güncellemeler
            genreUpdate.GenreName = model.genre.GenreName;
        
            // Resmi yükleme işlemi
         

            cm.TUpdate(genreUpdate);
            c.SaveChanges();

            return RedirectToAction("Category", "CategoryList");
        }

        public IActionResult CategoryMovie(int id)
        {
           var values = gm.GetListCategoryMovies(id);
            var dizi = mm.GetMoviesByListIDforCategory(values);

            var genre = new CategoryViewModel
            {
                movies = dizi,
                genreID=id,
            };

            return View(genre);

        }



        public IActionResult CategoryDontMovie(int id)
        {
            var values = gm.GetListCategoryMovies(id);
            if (values.Count >0)
            {
                var dizi = mm.GetMoviesByListIDfDontCategory(values);

                var genre = new CategoryViewModel
                {
                    movies = dizi,
                    genreID = id,
                };

                return View(genre);
            }

             var genree = new CategoryViewModel
                {
                    movies = mm.GetList(),
                    genreID = id,
                };

                return View(genree);
           

        }
        [HttpPost]
        public async Task<IActionResult> CategoryDontMovie(int selectedMovieId, int genreId)
        {
            GenreCon genreCon = new GenreCon();
            genreCon.GenreID = genreId;
            genreCon.MovieID = selectedMovieId;

            gm.TAdd(genreCon);
            c.SaveChanges();
            return RedirectToAction("Category", "CategoryList");
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAdd(string GenreName, Genre g)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult results = validator.Validate(g);
            if (results.IsValid)
            {
                g.GenreName = GenreName;
             
         
              

                cm.TAdd(g);
                c.SaveChanges();

                return RedirectToAction("Category", "CategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        [HttpPost]
        public IActionResult DeleteCategory(int genreID)
        {
            var userToDelete = c.Genres.FirstOrDefault(u => u.GenreID == genreID);
            if (userToDelete == null)
            {
                return NotFound();
            }

            cm.TDelete(userToDelete);
            c.SaveChanges();

            return RedirectToAction("Category");
        }



    }
}
