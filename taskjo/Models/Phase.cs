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
            this.tasks= new HashSet<Tasks>();
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
        public string phaseState { get; set; }

        public virtual ICollection<Tasks> tasks  {get; set; }
        public   virtual Project project { get; set; }
        //public virtual SprintBackLog sprintBackLog { get; set; }





    }
}