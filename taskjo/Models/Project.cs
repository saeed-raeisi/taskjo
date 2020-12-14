using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Project
    {
        public Project()
        {
            this.phases = new HashSet<Phase>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int projectId { get; set; }
        [DisplayName("نام پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        public string projectName { get; set; }
        [DisplayName("توضیحات پروژه")]
        public string projectDesc { get; set; }
        [UIHint("datepicker")]
        [DisplayName("تاریخ ایجاد پروژه")]
        public DateTime projectdate { get; set; }
        [DisplayName("وضعیت پروژه")]
        //string
        public int projectSate { get; set; }
        [DisplayName("مستندات پروژه")]
        public string projectDocFile { get; set; }



        //navigation
        public ICollection<Phase> phases  { get; set; }
        public virtual Team teams { get; set; }



    }
}