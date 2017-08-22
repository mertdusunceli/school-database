namespace SchoolSystem_Helsinki.Web.Models
{
    public class RoomLecture
    {
        public int Id { get; set; }
        public int Ref_Lecture { get; set; }
        public int Ref_Room { get; set; }
        public int? Active { get; set; }
    }
}
