using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class SprintBackLog
    {
        [Key]
        public int sprintId { get; set; }
        public DateTime sprintStartDate { get; set; }
        public DateTime sprintEndDate { get; set; }
        //[ForeignKey("state")]
        //public int sprintStateId{ get; set; }
        //[ForeignKey("phase")]
        //public int phaseId { get; set; }

        //navigation
        public virtual BackLog backlog { get; set; }
        public virtual Phase phase { get; set; }





    }
}