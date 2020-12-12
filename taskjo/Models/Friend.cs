using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Friend
    {
        
        [Key]
        public int friendId { get; set; }
        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual ICollection<Users> users { get; set; }

        public Friend()
        {
            this.users = new HashSet<Users>();
        }
        public int frienduser { get; set; }
    }
}