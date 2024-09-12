using EntityLayer.Concrete;

namespace MovieSite.Areas.Admin.Models
{
    public class HelpMessageViewModel
    {
        public List<HelpMessage> HelpMessages { get; set; }
        public List<int> UserIDs { get; set; }
        public List<User> User { get; set; }
    }
}