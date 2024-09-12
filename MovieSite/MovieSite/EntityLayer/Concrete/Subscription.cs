using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Subscription
    {
        [Key]
        public int SubscriptionID { get; set; }

        public string SubName { get; set; }
        public float Money { get; set; }

        public List<User> user { get; set; }







    }
}
