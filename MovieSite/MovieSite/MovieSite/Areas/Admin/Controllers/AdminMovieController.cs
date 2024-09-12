using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation;

using MovieSite.Areas.Admin.Models;
using DataAccesLayer.EntitiyFramework;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MovieSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class AdminMovieController : Controller
    {
        MovieManager mm = new MovieManager(new EFMovieRepository());
        GenreConManager gm = new GenreConManager(new EFGenreConRepository());
        Context c = new Context();
        ListConnectManager lc = new ListConnectManager(new EFListConnectRepository());
        public IActionResult Index( int page = 1)
        {
            var values =  mm.GetList();
            int pageSize = 12;
            var totalMovies = c.Movies.Count();

            var dizii = values.Skip((page - 1) * pageSize)
                   .Take(pageSize)
                   .ToList();
            var movie = new AdminMovieViewModel
            {
                movies = dizii,
                TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize),
                CurrentPage = page,
            };

            return View(movie);
        }


        [HttpGet]
        public IActionResult MovieViewPage(int MovieID)
        {
            var values = c.Movies.Where(x => x.MovieID == MovieID).FirstOrDefault();
            var deger = gm.GetListMoviesCategory(MovieID);
            var categories = mm.GetCategoriesByListIDforMovies(deger);

            var listDeger = lc.GetListMoviesList(MovieID);
            var lists = mm.GetListByListIDforMovies(listDeger);
            var movie = new AdminMovieViewModel
            {
                movieID = MovieID,
                movie = values,
                genres = categories,
                lists = lists
            };
            return View(movie);
        }

        [HttpPost]
        public IActionResult MovieViewPage(AdminMovieViewModel model, IFormFile Image)
        {
            var movieUpdate = c.Movies.FirstOrDefault(u => u.MovieID == model.movieID);
            if (movieUpdate == null)
            {
                return NotFound();
            }

            // Diğer güncellemeler
            movieUpdate.Name = model.movie.Name;
            movieUpdate.Description = model.movie.Description;
            movieUpdate.ReleaseDate = model.movie.ReleaseDate;
            movieUpdate.RunningTime = model.movie.RunningTime;

            // Resmi yükleme işlemi
            if (Image != null && Image.Length > 0)
            {
                // Dosya adını ve yolu belirleyin
                var fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/filmSitesi/filmsitesi/image", fileName);

                // Dosyayı kaydet
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                // Resim yolunu veritabanında saklayabilirsiniz
                movieUpdate.Image = "/filmSitesi/filmsitesi/image/" + fileName;
            }

            mm.TUpdate(movieUpdate);
            c.SaveChanges();

            return RedirectToAction("Index", "AdminMovie");
        }
        [HttpPost]
        public IActionResult DeleteMovies(int movieId)
        {
            var userToDelete = c.Movies.FirstOrDefault(u => u.MovieID == movieId);
            if (userToDelete == null)
            {
                return NotFound();
            }

            mm.TDelete(userToDelete);
            c.SaveChanges();

            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult MovieAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MovieAdd(string Name,string Description,string Url,DateTime ReleaseDate,int RunningTime,IFormFile Image,Movie m)
        {
            MovieValidator validator = new MovieValidator();
            ValidationResult results = validator.Validate(m);
            if (results.IsValid)
            {
                m.Name = Name;
                m.Description = Description;
                m.ReleaseDate = ReleaseDate;
                m.RunningTime = RunningTime;
                m.Url = Url;
                m.AvgRating = 0;
                // Resmi yükleme işlemi
                if (Image != null && Image.Length > 0)
                {
                    // Dosya adını ve yolu belirleyin
                    var fileName = Path.GetFileName(Image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/filmSitesi/filmsitesi/image", fileName);

                    // Dosyayı kaydet
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }

                    // Resim yolunu veritabanında saklayabilirsiniz
                    m.Image = "/filmSitesi/filmsitesi/image/" + fileName;
                }


                mm.TAdd(m);
                c.SaveChanges();

                return RedirectToAction("Index", "AdminMovie");
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
        public IActionResult DeleteCategories(int movieId,int GenreID)
        {
            var userToDelete = c.GenreCons.FirstOrDefault(u => u.MovieID == movieId && u.GenreID== GenreID);
            if (userToDelete == null)
            {
                return NotFound();
            }

            gm.TDelete(userToDelete);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteList(int movieId, int ListID)
        {
            var userToDelete = c.ListConnects.FirstOrDefault(u => u.MovieID == movieId && u.ListID == ListID);
            if (userToDelete == null)
            {
                return NotFound();
            }

            lc.TDelete(userToDelete);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
