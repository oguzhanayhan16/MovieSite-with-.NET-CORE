using EntityLayer.Concrete;

namespace MovieSite.Areas.Admin.Models
{
    public class ClientViewModel
    {
        public List<User> users { get; set; }
        public List<Subscription> sub { get; set; }
        public User user { get; set; }
        public int userID { get; set; }
        public List<Role> Roles { get; set; }
        public string UserRoles { get; set; }  // Add this property 
    }
}
