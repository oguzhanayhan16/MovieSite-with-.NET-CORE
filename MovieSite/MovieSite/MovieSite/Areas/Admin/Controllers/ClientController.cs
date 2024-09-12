using BusinessLayer.Concrate;
using DataAccesLayer.EntitiyFramework;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieSite.Areas.Admin.Models;

namespace MovieSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class ClientController : Controller
    {
        UserManager um = new UserManager(new EFUserRepository());
        SubscriptionManager sb = new SubscriptionManager(new EFSubscriptionRepository());
        CommentManager cm = new CommentManager(new EFCommentRepository());
        RoleManager rm = new RoleManager(new EFRoleRepostiyory());
        Context c = new Context();
        public IActionResult Index()
        {
         var values=   um.GetListWithClientPaidSub();
            var subc = sb.GetList();
            var model = new ClientViewModel()
            {
                users = values,
                sub=subc
            };
            return View(model);
        }

        public IActionResult DontSub()
        {
            var values = um.GetListWithClientDontSub();
            var model = new ClientViewModel()
            {
                users = values,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult ClientProfile(int userID)
        {

            List<SelectListItem> roleValues = (from x in rm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.RoleName,
                                                       Value = x.RoleID.ToString(),
                                                   }).ToList();
            ViewBag.cv = roleValues;
            var role = rm.GetList();

            var user = c.Users.Where(x=>userID == x.UserID).FirstOrDefault();
            var model = new ClientViewModel()
            {
                Roles = role,
                userID = userID,
                user=user
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult ClientProfile(ClientViewModel model)
        {
   
            var userToUpdate = c.Users.FirstOrDefault(u => u.UserID == model.userID);
            if (userToUpdate == null)
            {
               
                return NotFound();
            }

            userToUpdate.FirstName = model.user.FirstName;
            userToUpdate.LastName = model.user.LastName;
            userToUpdate.Username = model.user.Username;
            userToUpdate.Email = model.user.Email;
            userToUpdate.RoleID = model.user.RoleID;

            um.TUpdate(userToUpdate);

            c.SaveChanges();

            return RedirectToAction("Index");

           
        }
        [HttpPost]
        public IActionResult DeleteClientProfile(int userID)
        {
            var userToDelete = c.Users.FirstOrDefault(u => u.UserID == userID);
            if (userToDelete == null)
            {
                return NotFound();
            }

            um.TDelete(userToDelete);
            c.SaveChanges();

            return RedirectToAction("Index"); // Örneğin, kullanıcı listesini gösteren bir sayfaya yönlendirin
        }


        public IActionResult GetComment(int id)
        {
            var values = cm.FindCommentMovie(id);
            var comment = cm.GetCommentMovie(values);
            var getcomment = cm.GetListCom(id);

            var model = new CommentViewModel()
            {
                movies=comment,
                comments=getcomment,

            };
            return View(model);
        }

    }
}
