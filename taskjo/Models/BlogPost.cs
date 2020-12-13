using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.users = new HashSet<Users>();
        }

        [Key]
        public int userListId { get; set; }
        //public int projectId { get; set; }

        //[ForeignKey("projectId")]
        //public virtual project_tbl project { get; set; }
        public int userId { get; set; }

        [ForeignKey("userId")]
        public virtual ICollection<Users> users { get; set; }
      
    }
}