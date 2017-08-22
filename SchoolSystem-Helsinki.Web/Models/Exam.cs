using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem_Helsinki.Web.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int Ref_Lecture { get; set; }
        public int Ref_Personnel { get; set; }
        public string Status { get; set; }
        public int Grade { get; set; }
        public int? Active { get; set; }
    }
}