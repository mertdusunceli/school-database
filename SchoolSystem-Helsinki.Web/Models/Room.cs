namespace SchoolSystem_Helsinki.Web.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Floor { get; set; }
        public int? Active { get; set; }
    }
    
}