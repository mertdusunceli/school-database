using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem_Helsinki.Web.Models
{
    public class RoomPersonnel
    {
        public int Id { get; set; }
        public int Ref_Room { get; set; }
        public int Ref_Personnel { get; set; }
        public int? Active { get; set; }
    }
}

