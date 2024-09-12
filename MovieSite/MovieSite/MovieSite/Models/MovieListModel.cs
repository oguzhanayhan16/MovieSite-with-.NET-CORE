using EntityLayer.Concrete;

namespace MovieSite.Models
{
    public class MovieListModel
    {
        public List<ListC> ListC { get; set; }
        public List<Movie> Movies { get; set; }

        public List<ListConnect> ListConnect { get; set; }
        public bool? userPaid { get; set; }
        public int? userID { get; set; }
        public int? roleID { get; set; }

        public User user { get; set; }
        public List<Collection> collec { get; set; }

        public List<Genre> genres { get; set; }
        public Genre genre { get; set; }

        public HelpMessage help { get; set; }

        public List<HelpMessage> messages { get; set; }
        public int UserID { get; set; }


        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
