using EntityLayer.Concrete;

namespace MovieSite.Areas.Admin.Models
{
    public class CommentViewModel
    {

        public List<Movie> movies { get; set; }
        public List<User> users { get; set; }
        public List<Comment> comments { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

    }
}
