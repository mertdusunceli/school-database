using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem_Helsinki.Web.Models
{
    public class Task
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Authorization { get; set; }
        public int? Active { get; set; }

    }
}