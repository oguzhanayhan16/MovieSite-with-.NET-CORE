using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int RatingValue { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        public int MovieID { get; set; }
        [ForeignKey("MovieID")]
        public Movie movie { get; set; }
    }
}
