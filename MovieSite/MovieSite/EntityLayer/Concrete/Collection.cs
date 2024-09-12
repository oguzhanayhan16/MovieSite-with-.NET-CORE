using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Collection
    {
        [Key]
        public int CollectionID { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        public int MovieID { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }

        [Range(0, 10)]
        public int? Rating { get; set; }

        public string? Comments { get; set; }

        public bool? Wishlist { get; set; }

        public bool? Watched { get; set; }


    }
}
