using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int phaseId { get; set; }
        public string phaseName { get; set; }
        public string phaseTitle { get; set; }
        public string phasePicture { get; set; }
        public string phaseBacklog { get; set; }

        public virtual ICollection<Task> tasks  {get; set; }
        public   virtual Project project { get; set; }
        

    }
}