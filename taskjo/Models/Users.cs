using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Users
    {
        [Key]
        public int userId { get; set; }
        //[DisplayName("نام")]
        //[Required(ErrorMessage = "{0} is required")]
        //[StringLength(150)]
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }

        public virtual Friend friend { get; set; }
        public virtual project_users_tbl project_users { get; set; }

    }
}