using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class GenreCon
    {
        [Key]
        public int GenreConID { get; set; }
        public int MovieID { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }

        public int GenreID { get; set; }
        [ForeignKey("GenreID")]
        public Genre Genre { get; set; }

    }
}
