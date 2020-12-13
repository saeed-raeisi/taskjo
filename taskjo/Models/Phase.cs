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
        public int phaseState { get; set; }

        public virtual ICollection<Task> tasks  {get; set; }
        public   virtual Project project { get; set; }
        

    }
}