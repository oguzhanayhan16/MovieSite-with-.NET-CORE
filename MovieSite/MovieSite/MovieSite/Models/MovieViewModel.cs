using EntityLayer.Concrete;

namespace MovieSite.Models
{
    public class MovieViewModel
    {
        public User Users { get; set; }
        public List<Movie> Movies { get; set; }

        public List<Thumb> Thumbs { get; set; }

        public List<Collection> collec { get; set; }
        public Comment com { get; set; }
        public string MovieUrl { get; set; }

        public int? userID { get; set; }
        public bool Spoiler { get; set; }
    }
}
