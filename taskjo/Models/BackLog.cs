using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class BackLog
    {
        [Key]
        public int backlogId { get; set; }
        [DisplayName("عنوان نیاز ")]
        [StringLength(50)]
        public string   backlogTitle { get; set; }
        [DisplayName("توضیحات نیاز ")]
        [StringLength(50)]
        public string baclogDesc { get; set; }
        //[ForeignKey("importance")]
        //public int importanceId { get; set; }
        //navigation
        public virtual Project project { get; set; }
        public virtual Importance importance { get; set; }



    }
}