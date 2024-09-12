using BusinessLayer.Concrate;
using DataAccesLayer.EntitiyFramework;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieSite.Areas.Admin.Models;
using Newtonsoft.Json.Linq;

namespace MovieSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class AdminMessageController : Controller
    {
        HelpMessageManager hm = new HelpMessageManager(new EFHelpMessageRepository());
        UserManager um = new UserManager(new EFUserRepository());
        Context c = new Context();
        public IActionResult Index()
        {
           var values =hm.GetListAdminMessageId();

            var model = new AdminMessageViewModel
            {
                messages = hm.GetListAdminMessage(),
                users=hm.GetListHelpMessageByUser(values)

        };
            return View(model);
        }

        public IActionResult MailBox(int messageID,int userID)
        {
            var values = hm.GetListMessageByID(messageID);
            var user = um.getUser(userID);
            var model = new AdminMessageViewModel
            {
                message = values,
                user = user,

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

            return RedirectToAction("Index");
        }

        public IActionResult SendMessageAdmin(int messageID,int userID)
        {
            var values = hm.GetListMessageByID(messageID);
            var user = um.getUser(userID);
            var model = new AdminMessageViewModel
            {
                message = values,
                user = user,

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SendMessageAdmin(HelpMessage help,int messageID, int userID, string email, string subject, string textarea)
        {
          
            help.UserID = 4;
            help.MessageContent = textarea;
            help.MessageTittle = subject;
            help.ReceiverID = userID;
            help.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            hm.TAdd(help);
            return RedirectToAction("Index");
        }

        public IActionResult AdminSendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminSendMessage(HelpMessage help, int messageID, string email, string subject, string textarea)
        {
            var user = um.getUserEmail(email);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Email adresi hatalıdır.";
                return View();
            }

            var userID = c.Users.Where(x => x.Email == email).Select(y => y.UserID).FirstOrDefault();

            help.UserID = 4;
            help.MessageContent = textarea;
            help.MessageTittle = subject;
            help.ReceiverID = userID;
            help.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            hm.TAdd(help);
            return RedirectToAction("Index");
        }

        public IActionResult SentMessage()
        {
            var values = hm.GetSendingMessageByID();
            var model = new AdminMessageViewModel
            {

                messages = hm.GetSendingMessageBy(),
                users = hm.GetListHelpMessageByUser(values)

            };
            return View(model);
        }


    }
}
