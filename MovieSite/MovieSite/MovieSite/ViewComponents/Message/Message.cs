using BusinessLayer.Concrate;
using DataAccesLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using MovieSite.Areas.Admin.Models;

namespace MovieSite.ViewComponents.Message
{
    public class Message : ViewComponent
    {
        HelpMessageManager hm = new HelpMessageManager(new EFHelpMessageRepository());
        public IViewComponentResult Invoke()
        {
            var helpMessages = hm.GetListAdminMessage(); 
            var message = hm.Take3GetList(helpMessages); 
            var userIds = helpMessages.Select(m => m.UserID).ToList(); // UserID'leri al
            var user = hm.GetMessageUser(userIds);
            var model = new AdminMovieViewModel
            {
                HelpMessages = message,
                UserIDs = userIds,
                User = user
            };


            return View(model);
        }
    }
}
