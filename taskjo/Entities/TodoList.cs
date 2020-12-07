using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taskjo.Models
{
    public class TodoList
    {
        public int todoId { get; set; }
        public int todoTitle { get; set; }
        public DateTime todoDate { get; set; }
    }
}