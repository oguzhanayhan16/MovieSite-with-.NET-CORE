using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{


    public class User
    {
        [Key]
        public int UserID { get; set; }


        public string Username { get; set; }


        public string? Password { get; set; }
        public string? ConfrimPass { get; set; }


        public string? FirstName { get; set; }


        public string? LastName { get; set; }

        public string? Email { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Logged { get; set; }

        public DateTime? PaidUntilDate { get; set; }

        public DateTime? LastLogin { get; set; }

        public int Likes { get; set; }

        public string Avatar { get; set; }

        public int SubscriptionID { get; set; }
        [ForeignKey("SubscriptionID")]
        public Subscription Subscription { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role Role { get; set; }


        public List<Thumb> thumbs { get; set; }
        public List<Collection> Collection { get; set; }
        public List<HelpMessage> HelpMessage { get; set; }
        public List<Comment> Comment { get; set; }

        public List<Rating> Rating { get; set; }

    }

}

