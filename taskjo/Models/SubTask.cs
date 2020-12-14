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
        [DataType(DataType.MultilineText)]
        [DisplayName("توضیحات زیر وظیفه")]
        [StringLength(150)]
        public string subTascDesc { get; set; }
        //[ForeignKey("state")]
        [DisplayName("وضعیت زیر وظیفه")]
        public string subTaskState { get; set; }
        //[ForeignKey("task")]

        //public int taskId { get; set; }
        //[ForeignKey("user")]

        public string userName { get; set; }
        //navigation

        public virtual Tasks task { get; set; }
        public virtual Users user{ get; set; }




    }
}