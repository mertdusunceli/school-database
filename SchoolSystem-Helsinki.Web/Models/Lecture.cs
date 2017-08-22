namespace SchoolSystem_Helsinki.Web.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string LectureName { get; set; }
        public string LectureRef { get; set; }
        public int Credit { get; set; }
        public int? Ref_Department { get; set; }
        public int? Active { get; set; }

    }
}