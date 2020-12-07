using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class project_tbl
    {
        [Key]
        public int projectId { get; set; }
        public int projectAdmin { get; set; }
        public string projectName { get; set; }
        public string des { get; set; }
        //public int userListId { get; set; }
        //[ForeignKey("userListId")]
        //public virtual project_users_tbl project_user { get; set; }
        public int groupId { get; set; }
        [ForeignKey("groupId")]
        public virtual group_tbl group { get; set; }

    }
}