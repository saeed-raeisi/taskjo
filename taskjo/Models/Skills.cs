using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Skills
    {
        [Key]
        public int skillid { get; set; }
        [Display(Name = "نام مهارت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنيد")]
        public string skillname { get; set; }
        // public int cateskillId { get; set; }
        // [ForeignKey("cateskillId")]
        public virtual CateSkill catskillfk { get; set; }
    }
}