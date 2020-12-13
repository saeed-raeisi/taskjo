using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int taskId { get; set; }
        [DisplayName("عنوان وظیفه")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        public string taskName { get; set; }
        [DisplayName("توضیحات وظیفه")]
        public string taskDesc { get; set; }
        public int taskState { get; set; }
        public virtual Phase phaseidFk { get; set; }





    }
}