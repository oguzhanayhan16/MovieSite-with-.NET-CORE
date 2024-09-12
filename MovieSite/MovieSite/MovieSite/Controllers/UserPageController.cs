using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntitiyFramework;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieSite.Models;

namespace MovieSite.Controllers
{
    [AllowAnonymous]
    public class UserPageController : Controller
    {
        CollectionManager cl = new CollectionManager(new EFCollectionRepository());
        Context c = new Context();
        MovieManager mm = new MovieManager(new EFMovieRepository());
        UserManager um = new UserManager(new EFUserRepository());
        HelpMessageManager hm = new HelpMessageManager(new EFHelpMessageRepository());

        [HttpPost]
        public IActionResult UpdateStatus(int movieID, string action, int userID)
        {
            try
            {
                var collection = cl.GetByCollection(userID, movieID);
                if (collection == null)
                {
                    Collection col = new Collection
                    {
                        UserID = userID,
                        MovieID = movieID
                    };

                    if (action == "Watched")
                    {
                        col.Watched = true;
                        cl.TAdd(col);
                        return Ok(new { message = "Başarıyla İzlenilenlere eklenmiştir." });
                    }
                    else if (action == "Wishlist")
                    {
                        col.Wishlist = true;
                        cl.TAdd(col);
                        return Ok(new { message = "Başarıyla Kaydedilmiştir." });
                    }
                }
                else
                {
                    if (action == "Watched")
                    {

                        if (collection.Watched == null)
                        {
                            collection.Watched=true;
                            cl.TUpdate(collection);
                            if (collection.Watched == true)
                            {

                                return Ok(new { message = "Başarıyla İzlenilenlere eklenmiştir." });
                            }
                        }
                        else
                        {
                            collection.Watched = !collection.Watched;
                            cl.TUpdate(collection);

                            if (collection.Watched == true)
                            {
                                return Ok(new { message = "Başarıyla İzlenilenlere eklenmiştir." });
                            }
                            else
                            {
                                return Ok(new { message = "Başarıyla İzlenilenlerden silinmiştir." });
                            }
                        }
                       
                    }
                    else if (action == "Wishlist")
                    {
                        if (collection.Wishlist==null)
                        {
                            collection.Wishlist =true;
                            cl.TUpdate(collection);

                            if (collection.Wishlist == true)
                            {
                                return Ok(new { message = "Başarıyla Kaydedilmiştir." });
                            }
                        }

                        else {
                            collection.Wishlist = !collection.Wishlist;
                            cl.TUpdate(collection);

                            if (collection.Wishlist == true)
                            {
                                return Ok(new { message = "Başarıyla Kaydedilmiştir." });
                            }
                            else
                            {
                                return Ok(new { message = "Başarıyla Kaydedilenlerden silinmiştir." });
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }

            return BadRequest(new { message = "Geçersiz işlem." });
        }
        public IActionResult WishlistPage(int userID, int page = 1)
        {
            var values = c.Collections.Where(c => c.UserID == userID && c.Wishlist == true).ToList();
            var totalMovies = c.Collections.Where(c => c.UserID == userID && c.Wishlist == true).Count();
            int pageSize = 15;
            var moviesInCollection = values.Select(c => c.MovieID).ToList();
            var moviee = c.Movies.Where(m => moviesInCollection.Contains(m.MovieID));
            var dizii = moviee.Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

            var model = new MovieListModel
            {
                Movies = dizii,
                collec=values,
                TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize),
                CurrentPage = page,
                userID = userID

            };
            
            return View(model);
        }

        public IActionResult WatchedPage(int userID, int page = 1)
        {
            var values = c.Collections.Where(c => c.UserID == userID && c.Watched == true).ToList();
            var totalMovies = c.Collections.Where(c => c.UserID == userID && c.Watched == true).Count();
            int pageSize = 15;
            var moviesInCollection = values.Select(c => c.MovieID).ToList();
            var moviee = c.Movies.Where(m => moviesInCollection.Contains(m.MovieID));
            var dizii = moviee.Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

            // WishlistPage işlemleri
            var model = new MovieListModel
            {
                Movies = dizii,
                collec = values,
                TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize),
                CurrentPage = page,
                userID = userID

            };

            return View(model);
        }

        public IActionResult ProfilPage(int userID)
        {
            var values = c.Users.FirstOrDefault(c => c.UserID == userID);

            var model = new MovieListModel
            {
                user = values,
                userID = userID

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult ProfilPage(MovieListModel model)
        {
           
                var userToUpdate = c.Users.FirstOrDefault(u => u.UserID == model.userID);
                if (userToUpdate == null)
                {
                    // Handle the case where the user is not found
                    return NotFound();
                }

                // Update user properties
                userToUpdate.FirstName = model.user.FirstName;
                userToUpdate.LastName = model.user.LastName;
                userToUpdate.Username = model.user.Username;
                userToUpdate.Email = model.user.Email;

                // Update the user using the update method in your service layer
                um.TUpdate(userToUpdate);

                // Save changes to the database context if needed
                c.SaveChanges();

                return RedirectToAction("ProfilPage", new { userID = model.userID });
          
        }
        public IActionResult HelpPage(int userID)
        {

            var user = c.Users.FirstOrDefault(c => c.UserID == userID);

            var model = new MovieListModel
            {
                user = user,
                userID = userID,
                help = new HelpMessage() 
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult HelpPage(MovieListModel model)
        {
            model.help.UserID = model.UserID;
            model.help.ReceiverID = 4;
            model.help.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            hm.TAdd(model.help);
            return RedirectToAction("HelpPage", "UserPage");
        }

        public IActionResult GetMessage(int userID)
        {
            var values = hm.GetListUserViewMessage(userID);

            var model = new MovieListModel
            {
                userID = userID,
                messages = values,
            };

            return View(model);
        }


        public IActionResult ViewMessage(int messageID,int userID)
        {
            var values = hm.GetListMessageByID(messageID);

            var model = new MovieListModel
            {
                userID = userID,
                help = values,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult MailDelete(int messageID)
        {
            var userToDelete = c.HelpMessages.FirstOrDefault(u => u.MessageID == messageID);
            if (userToDelete == null)
            {
                return NotFound();
            }

            hm.TDelete(userToDelete);
            c.SaveChanges();

            return RedirectToAction("LogMovie","Movie");
        }
    }
}

