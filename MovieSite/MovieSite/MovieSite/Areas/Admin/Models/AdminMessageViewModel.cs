using EntityLayer.Concrete;

namespace MovieSite.Areas.Admin.Models
{
    public class AdminMessageViewModel
    {
        public List<HelpMessage> messages { get; set; }
        public List<User> users { get; set; }
        public HelpMessage message { get; set; }
        public User user { get; set; }

    }
}
