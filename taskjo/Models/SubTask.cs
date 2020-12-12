using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class SubTask
    {
        [Key]
        public int subtaskId { get; set; }
        public string subtaskName { get; set; }
        public int userIdFk { get; set; }
        public string subtascDesc { get; set; }
        public int subtaskState { get; set; }
        public int taskidFk { get; set; }


    }
}