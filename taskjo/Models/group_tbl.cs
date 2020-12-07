using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace taskjo.Models
{
    public class group_tbl
    {
        public group_tbl()
        {
            this.prjects = new HashSet<project_tbl>();
        }

        [Key]
        public int groupId { get; set; }
        public int groupAdmin { get; set; }
        public string groupName { get; set; }
        public string des { get; set; }

        public virtual ICollection<project_tbl> prjects { get; set; }
       
    }
}