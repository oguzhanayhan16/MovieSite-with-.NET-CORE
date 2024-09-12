using EntityLayer.Concrete;

namespace MovieSite.Models
{
  
        public class HelpPageViewModel
        {
            public int UserID { get; set; }
            public User User { get; set; }
            public HelpMessage HelpMessage { get; set; }
        }

}
