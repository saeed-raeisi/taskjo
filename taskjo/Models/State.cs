using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class State
    {
        [ForeignKey("phase")]
        public int stateId { get; set; }
        [DisplayName("وضعیت")]
        [StringLength(50)]
        public string stateName { get; set; }

        public virtual Phase phase { get; set; }
        //public virtual Task task { get; set; }

       //public virtual SprintBackLog sprintBackLog { get; set; }

        //public virtual SubTask subTask { get; set; }

        //public virtual Project project { get; set; }


    }
}