using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ListConnect
    {
        [Key]
        public int LConnectID { get; set; }
        public int MovieID { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }
        public int ListID { get; set; }
        [ForeignKey("ListID")]
        public ListC ListC { get; set; }
    }
}
