using IdentitySample.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class TeamMembers
    {
        [Key]
        public int teamMemberId { get; set; }
        [DisplayName("تیم")]
        public int teamId { get; set; }
        //public string userId { get; set; }
        [DisplayName("نقش")]
        [StringLength(50)]
        public string memberRole { get; set; }


        //navigation
        public virtual Team team { get; set; }

        [ForeignKey("ApplicationUser")]
        [DisplayName("کاربر")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}