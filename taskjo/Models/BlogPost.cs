using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class BlogPost
    {


        [Key]
        public int postId { get; set; }
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        public string postTitle { get; set; }
        [DisplayName("تاریخ ")]
        public DateTime postDate { get; set; }
        [DisplayName("متن")]
        [Required(ErrorMessage = "لطفا {0} را وراد کنید")]
        public string postDesc { get; set; }
        [DisplayName("عکس")]
        public string postPicture { get; set; }

        //navigation
        //public virtual Users users { get; set; }
      
    }
}