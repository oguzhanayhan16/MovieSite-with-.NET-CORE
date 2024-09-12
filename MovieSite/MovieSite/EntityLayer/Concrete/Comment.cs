using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int MovieID { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        public string CommentTittle { get; set; }
        public string CommentContent { get; set; }
        public int? Position { get; set; }
        public int? Likes { get; set; }
        public bool Spoiler { get; set; }
        public DateTime? CommentDate { get; set; }
        public bool? CommentStatus { get; set; }

    }
}
