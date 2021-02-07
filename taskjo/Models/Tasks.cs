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
        public Tasks()
        {
            this.SubTasks = new HashSet<SubTask>();
        }




        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int taskId { get; set; }
        [DisplayName("عنوان وظیفه")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        public string taskName { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("توضیحات وظیفه")]
        public string taskDesc { get; set; }
        //[ForeignKey("state")]
        [DisplayName("وضعیت وظیفه")]
        public string taskState { get; set; }
        [DisplayName("نام فاز")]
        public int phaseId { get; set; }
        //navigation
        public virtual Phase phase { get; set; }
        public virtual ICollection<SubTask> SubTasks { get; set; }







    }
}