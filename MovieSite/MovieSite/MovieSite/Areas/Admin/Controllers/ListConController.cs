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
using Microsoft.AspNetCore.Authorization;

namespace MovieSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class ListConController : Controller
    {
        ListCManager lc = new ListCManager(new EFListCRepository());
        Context c = new Context();
        ListConnectManager cm = new ListConnectManager(new EFListConnectRepository());
        MovieManager mm = new MovieManager(new EFMovieRepository());
        public IActionResult List()
        {

            var model = new ListViewModel
            {
                list= lc.GetList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult ListDetails(int id)
        {
            var values = c.ListCs.Where(x => x.ListID == id).FirstOrDefault();

            var list = new ListViewModel
            {

                listID = id,
                listC = values

            };



            return View(list);
        }
        [HttpPost]
        public IActionResult ListDetails(ListViewModel model)
        {
            var genreUpdate = c.ListCs.FirstOrDefault(u => u.ListID == model.listID);
            if (genreUpdate == null)
            {
                return NotFound();
            }

            // Diğer güncellemeler
            genreUpdate.ListName = model.listC.ListName;

            // Resmi yükleme işlemi


            lc.TUpdate(genreUpdate);
            c.SaveChanges();

            return RedirectToAction("Category", "CategoryList");
        }

        public IActionResult ListMovie(int id)
        {
            var values = cm.GetListMovies(id);
            var dizi = mm.GetMoviesByListIDforCategory(values);

            var model = new ListViewModel
            {
                movies = dizi,
                listID = id,
            };

            return View(model);

        }
        public IActionResult ListDontMovie(int id)
        {
            var values = cm.GetListMovies(id);
            if (values.Count > 0)
            {
                var dizi = mm.GetMoviesByListIDfDontCategory(values);

                var genre = new ListViewModel
                {

                    movies = dizi,
                    listID = id,
                };

                return View(genre);
            }

            var model = new ListViewModel
            {
                movies = mm.GetList(),
                listID = id,
            };

            return View(model);


        }

        [HttpPost]
        public async Task<IActionResult> ListDontMovie(int selectedMovieId, int listID)
        {
            ListConnect listCon = new ListConnect();
            listCon.ListID = listID;
            listCon.MovieID = selectedMovieId;

            cm.TAdd(listCon);
            c.SaveChanges();
            return RedirectToAction("List", "ListCon");
        }
        [HttpPost]
        public IActionResult DeleteList(int listID)
        {
            var userToDelete = c.ListCs.FirstOrDefault(u => u.ListID == listID);
            if (userToDelete == null)
            {
                return NotFound();
            }

            lc.TDelete(userToDelete);
            c.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult ListAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ListAdd(string ListName, ListC g)
        {
            ListValidator validator = new ListValidator();
            ValidationResult results = validator.Validate(g);
            if (results.IsValid)
            {
                g.ListName = ListName;




                lc.TAdd(g);
                c.SaveChanges();

                return RedirectToAction("List", "ListCon");
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
    

    }
}
