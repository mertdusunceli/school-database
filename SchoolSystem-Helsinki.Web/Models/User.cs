using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem_Helsinki.Web.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int Ref_Personnel { get; set; }
        public int? Active { get; set; }
    }
}