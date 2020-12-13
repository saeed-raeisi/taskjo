using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class SubTask
    {
        [Key]
        public int subtaskId { get; set; }
        [DisplayName("نام زیر وظیفه")]
        [StringLength(50)]
        public string subTaskName { get; set; }
        [DisplayName("توضیحات زیر وظیفه")]
        [StringLength(150)]
        public string subTascDesc { get; set; }
        //[ForeignKey("state")]
        //public int subTaskStateId { get; set; }
        //[ForeignKey("task")]

        //public int taskId { get; set; }
        //[ForeignKey("user")]

        //public int userId { get; set; }
        //navigation

        public virtual Task task { get; set; }
        public virtual State state { get; set; }
        public virtual Users user{ get; set; }




    }
}