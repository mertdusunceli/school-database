namespace SchoolSystem_Helsinki.Web.Models
{
    public class School
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public int SchoolPhone { get; set; }
        public string SchoolEmail { get; set; }
        public int? Active { get; set; }
       
    }
}