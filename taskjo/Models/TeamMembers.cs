using System;
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
        //[Key]
        //[Column(Order = 0)]
        public int teamId { get; set; }
        public int userId { get; set; }
        [DisplayName("نقش")]
        [StringLength(50)]
        public string memberRule { get; set; }


        //navigation
        public virtual Team team { get; set; }
        public virtual Users user { get; set; }

    }
}