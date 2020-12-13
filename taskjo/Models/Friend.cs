using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Friend
    {

        [Key]
        [Column(Order = 0)]
        public int userId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int friendId { get; set; }
        public virtual Users users { get; set; }

        
    }
}