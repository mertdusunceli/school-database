namespace SchoolSystem_Helsinki.Web.Models
{
    public class Personnel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public System.DateTime? GraduationDate { get; set; }
        public int? Grade { get; set; }
        public int Ref_department { get; set; }
        public int Ref_school { get; set; }
        public int? Active { get; set; }
    }
}
