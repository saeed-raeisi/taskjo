using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int taskId { get; set; }
        [DisplayName("عنوان وظیفه")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        public string taskName { get; set; }
        [DisplayName("توضیحات وظیفه")]
        public string taskDesc { get; set; }
        //[ForeignKey("state")]
        [DisplayName("وضعیت وظیفه")]
        public string taskState { get; set; }
        //[ForeignKey("phase")]
        //public int taskPhaseId { get; set; }
        //navigation
        public virtual Phase phase { get; set; }







    }
}