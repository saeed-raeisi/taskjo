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
        public Users()
        {
            this.friends = new HashSet<Friend>();
            this.Skills = new HashSet<Skills>();
            this.teams = new HashSet<Team>();

        }

        [Key]
        public int userId { get; set; }
        [DisplayName("نام")]
        [StringLength(50)]
        public string fname { get; set; }
        [StringLength(50)]
        [DisplayName("نام خانوادگی")]
        public string lname { get; set; }
        [Phone]
        [DisplayName("شماره تماس")]
        public string mobile { get; set; }
        [DisplayName("تاریخ تولد")]
        public DateTime? birthdate { get; set; }

        [EmailAddress]
        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        public string email { get; set; }
        // navigation
        public virtual ICollection<Friend> friends { get; set; }
        public virtual ICollection<Skills> Skills { get; set; }
        public virtual ICollection<Team> teams { get; set; }





    }
}