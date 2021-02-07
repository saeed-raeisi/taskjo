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

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teamId { get; set; }
        [DisplayName("اسم تیم")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        public string teamName { get; set; }
        [DisplayName("توضیحات  تیم")]
        [DataType(DataType.MultilineText)]
        public string teamDesc { get; set; }
        [DisplayName("تاریخ ایجاد تیم")]
        [UIHint("datepicker")]
        public DateTime teamStartDate { get; set; }
        [DisplayName("لوگو  تیم")]
        public string teamLogo { get; set; }


        //navigation
        public virtual ICollection<Project> prjects { get; set; }
        public virtual ICollection<TeamMembers> teamMembers { get; set; }




    }
}