using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class HelpMessage
    {
        [Key]
        public int MessageID { get; set; }
        public string MessageTittle { get; set; }
        public string MessageContent { get; set; }
        public int ReceiverID  { get; set; }
        public DateTime MessageDate { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
