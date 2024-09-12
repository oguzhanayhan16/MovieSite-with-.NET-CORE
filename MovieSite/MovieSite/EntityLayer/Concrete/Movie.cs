using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string? Name { get; set; }
        public string? Description{ get; set; }
        public DateTime? ReleaseDate { get; set; }
        public float AvgRating { get; set; }
        public string Url { get; set; }
        public string? Image { get; set; }
        public float? RunningTime { get; set; }

        public List<ListConnect> ListConnect { get; set; }
        public List<GenreCon> GenreCon { get; set; }
        public List<Thumb> thumbs { get; set; }
        public List<Collection> Collection { get; set; }
        public List<Comment> Comment { get; set; }
        public List<Rating> Rating { get; set; }
    }
}
