using BusinessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using MovieSite.Models;


namespace MovieSite.ViewComponents.Comment
{
    public class CommentListByMovie : ViewComponent
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());
        UserManager um = new UserManager(new EFUserRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetList(id);
            var userID = values.Select(x => x.UserID).ToList();
            var a = um.GetListWithCategoryByMovies(userID);

            var viewModel = new CommentViewModel
            {
                comment = values,
                userName=a
          
            };
            return View(viewModel);
        }
    }
}
