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
        [DisplayName("وضعیت زیر وظیفه")]
        public string subTaskState { get; set; }
        [DisplayName("فعال   ")]
        public Boolean is_active { get; set; }
        [DisplayName("وظیفه  ")]
        public int taskId { get; set; }

        public string username { get; set; }
        //navigation

        public virtual Tasks task { get; set; }
        //public virtual Users user{ get; set; }




    }
}