using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class TeamRule
    {
        [Key]
        public int ruleId { get; set; }
        public string ruleName { get; set; }

    }
}