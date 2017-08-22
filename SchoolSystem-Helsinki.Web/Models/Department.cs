namespace SchoolSystem_Helsinki.Web.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int? Ref_Faculty { get; set; }
        public int? Active { get; set; }

    }
}