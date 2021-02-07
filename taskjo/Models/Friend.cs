using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class Friend
    {
        [Key]
        public int friendId { get; set; }
        [DisplayName("کاربر     ")]
        public string userId { get; set; }
        [DisplayName("  دوست   ")]
        public string  userId_friend { get; set; }
        [DisplayName("فعال   ")]
        public Boolean is_active { get; set; }


    }
}