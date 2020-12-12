using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Task
    {
        [Key]
        public int taskId { get; set; }
        public string taskName { get; set; }
        public string taskDesc { get; set; }
        public int taskState { get; set; }
        public virtual Phase phaseidFk { get; set; }





    }
}