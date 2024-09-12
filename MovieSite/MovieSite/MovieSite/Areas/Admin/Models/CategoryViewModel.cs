using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MovieSite.Areas.Admin.Models
{
  
    public class CategoryViewModel
    {
        public List<Genre> category { get; set; }

        public int genreID { get; set; }

        public Genre genre { get; set; }
        public List<Movie> movies { get; set; }
        public List<Genre> genres { get; set; }
    }
}
