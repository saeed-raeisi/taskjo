using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class friend_tbl
    {
        [Key]
        public int friendId { get; set; }
        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual ICollection<user_tbl> users { get; set; }

        public friend_tbl()
        {
            this.users = new HashSet<user_tbl>();
        }
        public int frienduser { get; set; }
    }
}