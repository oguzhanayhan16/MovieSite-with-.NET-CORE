using EntityLayer.Concrete;

namespace MovieSite.Areas.Admin.Models
{
    public class AdminMovieViewModel
    {
        public List<Movie> movies { get; set; }

        public int movieID { get; set; }

        public Movie movie { get; set; }
        public List<Genre> genres { get; set; }
        public List<ListC> lists { get; set; }


        public List<HelpMessage> HelpMessages { get; set; }
        public List<int> UserIDs { get; set; }
        public List<User> User { get; set; }


        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

    }
}
