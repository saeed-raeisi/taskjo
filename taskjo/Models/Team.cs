using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace taskjo.Models
{
    public class Team
    {
        public Team()
        {
            this.prjects = new HashSet<Project>();
        }

        [Key,ForeignKey("teamMembers")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teamId { get; set; }
        [DisplayName("مدیر تیم")]
        public string teamAdmin { get; set; }
        [DisplayName("اسم تیم")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        public string teamName { get; set; }
        [DisplayName("توضیحات  تیم")]
        public string teamDesc { get; set; }
        public DateTime teamStartDate { get; set; }

        public string teamLogo { get; set; }

        public string enChar { get; set; }





        //navigation
        public virtual ICollection<Project> prjects { get; set; }
        public virtual ICollection<TeamMembers> teamMembers { get; set; }
        public virtual Users users { get; set; }


    }
}