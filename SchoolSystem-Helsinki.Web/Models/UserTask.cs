using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem_Helsinki.Web.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public int Ref_User { get; set; }
        public int Ref_Task { get; set; }
        public int? Active { get; set; }
    }
}