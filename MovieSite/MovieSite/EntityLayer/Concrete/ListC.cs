using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ListC
    {
        [Key ]
        public int ListID { get; set; }
        public string ListName { get; set; }

        public List<ListConnect> ListConnect { get; set; }
    }
}
