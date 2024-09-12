using EntityLayer.Concrete;

namespace MovieSite.Areas.Admin.Models
{
    public class ListViewModel
    {
        public List<ListC> list { get; set; }
        public int listID { get; set; }
        public ListC listC { get; set; }
        public List<Movie> movies { get; set; }
    }
}
