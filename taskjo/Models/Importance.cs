using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Importance
    {
        [ForeignKey("backLog")]
        public int importanceId { get; set; }
        [DisplayName("میزان اهمیت")]
        [StringLength(50)]
        public string importanceName { get; set; }

        public virtual BackLog backLog { get; set; }

    }
}