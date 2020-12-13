using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class TeamMembers
    {
        [Key]
        [Column(Order = 0)]
        public int teamId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int userId { get; set; }

        //navigation
        public virtual Team team { get; set; }
        public virtual Users user { get; set; }

    }
}