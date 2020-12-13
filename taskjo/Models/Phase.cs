using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Phase
    {
        public Phase()
        {
            this.tasks= new HashSet<Task>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int phaseId { get; set; }
        [DisplayName("عنوان فاز")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        public string phaseTitle { get; set; }
        [DisplayName("وضعیت فاز")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        //[ForeignKey("state")]
        //public int phaseStateId { get; set; }

        public virtual ICollection<Task> tasks  {get; set; }
        public   virtual Project project { get; set; }
        //public virtual SprintBackLog sprintBackLog { get; set; }
        public virtual State state { get; set; }





    }
}