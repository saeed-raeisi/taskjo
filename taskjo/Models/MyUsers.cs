using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class MyUsers 
    {
        //public MyUsers()
        //{
        //    //this.friends = new HashSet<Friend>();
        //    //this.teams = new HashSet<TeamMembers>();
        //    //this.subTask = new HashSet<SubTask>();

        //}

        [Key]
        public int myUserId { get; set; }
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

        //[EmailAddress]
        //[DisplayName("ایمیل")]
        //[Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        //public string email { get; set; }
        //[DisplayName("کاربر ")]
        // navigation
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}