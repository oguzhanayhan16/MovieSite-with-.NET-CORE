using BusinessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieSite.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private CommentManager cm = new CommentManager(new EFCommentRepository());

        [HttpPost]
        public IActionResult LikeComment(int commentId)
        {
            var comment = cm.TGetByID(commentId);
            if (comment != null)
            {
                comment.Likes++;
                cm.TUpdate(comment);
                return Json(new { success = true, likes = comment.Likes });
            }
            return Json(new { success = false });
        }

    }
}