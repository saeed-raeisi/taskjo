using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Skills
    {
        [Key]
        public int skillId { get; set; }

        public int SkillName { get; set; }

        public int SkillDesc { get; set; }

    }
}