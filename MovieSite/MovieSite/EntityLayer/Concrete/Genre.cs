using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }

        public string GenreName { get; set; }

        public List<GenreCon> GenreCon { get;set; }
    }
}
