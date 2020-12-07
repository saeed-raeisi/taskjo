using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Phase
    {
        [Key]
        public int phaseId { get; set; }
        public string phaseName { get; set; }
        public string phaseTitle { get; set; }
        public string phasePicture { get; set; }
        public string phaseBacklog { get; set; }

        //test for saeed


    }
}