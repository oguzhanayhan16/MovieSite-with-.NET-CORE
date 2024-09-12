using EntityLayer.Concrete;

namespace MovieSite.Models
{
    public class CommentViewModel
    {
      public  List<Comment> comment { get; set; }
      public List<User> userName { get; set; }
    }
}
