using EntityLayer.Concrete;
using DataAccessLayer.Concrate;
using BusinessLayer.ValidationRules;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using DataAccessLayer.EntitiyFramework;
using BusinessLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using MovieSite.Models;
namespace MovieSite.Controllers
{
    [AllowAnonymous]
    public class WatchMovieController : Controller
    {
        MovieManager mm = new MovieManager(new EFMovieRepository());
        UserManager um = new UserManager(new EFUserRepository());
        CommentManager cm = new CommentManager(new EFCommentRepository());
        CollectionManager cl = new CollectionManager(new EFCollectionRepository());
        Context c = new Context();


        private readonly AzureBlobService _blobService;

        public WatchMovieController(AzureBlobService blobService)
        {
            _blobService = blobService;
        }

        public IActionResult Index(int UserID, int MovieID)
        {
            var movie = c.Movies.Where(x => x.MovieID == MovieID).Select(y => y.Name).FirstOrDefault();
            var url = c.Movies.Where(x => x.MovieID == MovieID).Select(y => y.Url).FirstOrDefault();
            ViewBag.v = movie;
            ViewBag.v1 = MovieID;
            ViewBag.v2 = UserID;
           // var fileName = "14t29s29qft4.mp4"; 
            var containerName = "filmler"; 

            var movieUrl = _blobService.GetBlobUrl(url, containerName);

            var colletion = cl.GetList();

            var viewModel = new MovieViewModel
            {
                Users = um.getUser(UserID),
                collec =colletion,
                MovieUrl = movieUrl,
                com = new Comment()

            };
            return View(viewModel);

            

        }
        [HttpPost]
        public IActionResult Index(MovieViewModel viewModel, int MovieID, int UserID)
        {
            CommentValidator validator = new CommentValidator();
            ValidationResult results = validator.Validate(viewModel.com);

            if (results.IsValid)
            {
                viewModel.com.CommentTittle = "gereksiz";
                viewModel.com.CommentDate = DateTime.Now;
                viewModel.com.CommentStatus = true;
                viewModel.com.Likes = 0;
                viewModel.com.MovieID = MovieID;
                viewModel.com.UserID = UserID;
                viewModel.com.Spoiler = viewModel.Spoiler;

                cm.TAdd(viewModel.com);
                return RedirectToAction("Index", new { UserID = UserID, MovieID = MovieID });
            }

            return View(viewModel); // Hata durumunda formu tekrar göster
        }


    }
}
