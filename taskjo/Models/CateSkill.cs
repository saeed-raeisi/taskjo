using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class CateSkill
    {
        public CateSkill()
        {
            this.skills = new HashSet<Skills>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cateskillId { get; set; }
        [Display(Name = "دسته بندی مهارت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنيد")]
        public string  cateSkillName { get; set; }
        //navigation
        //[ForeignKey("groupId")]
        public virtual ICollection<Skills> skills { get; set; }
    }
}