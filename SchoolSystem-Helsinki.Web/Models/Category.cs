namespace SchoolSystem_Helsinki.Web.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}


//<authentication mode = "Forms" >
//    < forms loginUrl="/Login/Login"></forms>
//  </authentication>


//protected void CreateUser_Click(Kullanici bilgi)
//{
//    // Default UserStore constructor uses the default connection string named: DefaultConnection
//    //var userStore = new UserStore<IdentityUser>();
//    using (OkulSistemEntities db = new OkulSistemEntities())
//    {
//        bilgi.active = 1;
//        db.Kullanicis.Add(bilgi);
//    }
//}