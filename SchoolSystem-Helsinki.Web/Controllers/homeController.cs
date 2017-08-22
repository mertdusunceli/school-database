using SchoolSystem_Helsinki.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem_Helsinki.Web.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {

            return View();
        }

  

        public ActionResult SchoolList()
        {
            List<School> schools = new List<School>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Okuls.ToList();
                foreach (var schoolItem in model)
                {
                    School school = new School();
                    school.Id = schoolItem.id;
                    school.SchoolName = schoolItem.adi;
                    school.SchoolEmail = schoolItem.email;
                    school.SchoolPhone = schoolItem.telefon;
                    school.SchoolAddress = schoolItem.adres;

                    if (schoolItem.active.HasValue)
                    {
                        school.Active = schoolItem.active.Value;

                    }
                    else
                    {
                        schoolItem.active = 1;
                    }
                    schools.Add(school);
                }
            }
            return View(schools);
        }

        public ActionResult DepartmentList()
        {
            List<Department> departments = new List<Department>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Bolums.ToList();
                foreach (var departmentItem in model)
                {
                    Department department = new Department();
                    department.Id = departmentItem.id;
                    department.DepartmentName = departmentItem.adi;
                    if (departmentItem.active.HasValue)
                    {
                        department.Active = departmentItem.active.Value;

                    }
                    else
                    {
                        departmentItem.active = 1;
                    }
                    department.Ref_Faculty = departmentItem.ref_Fakulte;
                    departments.Add(department);

                }
            }
            return View(departments);
        }

        public ActionResult FacultyList()
        {
            List<Faculty> faculties = new List<Faculty>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Fakultes.ToList();
                foreach (var facultyItem in model)
                {
                    Faculty faculty = new Faculty();
                    faculty.Id = facultyItem.id;
                    faculty.FacultyName = facultyItem.fakulteAdi;
                    if (facultyItem.active.HasValue)
                    {
                        faculty.Active = facultyItem.active.Value;

                    }
                    else
                    {
                        facultyItem.active = 1;
                    }
                
                    faculties.Add(faculty);

                }
            }
            return View(faculties);
        }

        public ActionResult LectureList()
        {
            List<Lecture> lectures = new List<Lecture>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Ders.ToList();
                foreach (var lectureItem in model)
                {
                    Lecture lecture = new Lecture();
                    lecture.Id = lectureItem.id;
                    lecture.LectureName = lectureItem.ders_adi;
                    lecture.LectureRef = lectureItem.ders_referans;
                    lecture.Credit = lectureItem.kredi;
                    lecture.Ref_Department = lectureItem.ref_bolum;
                                  

                    if (lectureItem.active.HasValue)
                    {
                        lecture.Active = lectureItem.active.Value;

                    }
                    else
                    {
                        lectureItem.active = 1;
                    }
                    lectures.Add(lecture);
                }
            }
            return View(lectures);
        }

        public ActionResult RoomList()
        {
            List<Room> rooms = new List<Room>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Odas.ToList();
                foreach (var roomItem in model)
                {
                    Room room = new Room();
                    room.Id = roomItem.id;
                    room.RoomNumber = roomItem.oda_numara;
                    room.Floor = roomItem.kat;

                    if (roomItem.active.HasValue)
                    {
                        room.Active = roomItem.active.Value;

                    }
                    else
                    {
                        roomItem.active = 1;
                    }
                    rooms.Add(room);
                }
            }
            return View(rooms);
        }

        public ActionResult RoomLectureList()
        {
            List<RoomLecture> roomLectures = new List<RoomLecture>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Oda_Dersleri.ToList();
                foreach (var roomLectureItem in model)
                {
                    RoomLecture roomLecture = new RoomLecture();
                    roomLecture.Id = roomLectureItem.id;
                    roomLecture.Ref_Lecture = roomLectureItem.ref_DersId;
                    roomLecture.Ref_Room = roomLectureItem.ref_OdId;

                    if (roomLectureItem.active.HasValue)
                    {
                        roomLecture.Active = roomLectureItem.active.Value;

                    }
                    else
                    {
                        roomLectureItem.active = 1;
                    }
                    roomLectures.Add(roomLecture);

                }
            }
            return View(roomLectures);
        }

        public ActionResult PersonnelList()
        {
            List<Personnel> personnels = new List<Personnel>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Personels.ToList();
                foreach (var personnelItem in model)
                {
                    Personnel personnel = new Personnel();
                    personnel.Id = personnelItem.id;
                    personnel.FirstName = personnelItem.adi;
                    personnel.LastName = personnelItem.soyad;
                    personnel.Age = personnelItem.yas;
                    personnel.GraduationDate = personnelItem.mezun_tarih;
                    personnel.Grade = personnelItem.sinif;
                    personnel.Ref_department = personnelItem.ref_bolum;
                    personnel.Ref_school = personnelItem.ref_okul;

                    if (personnelItem.active.HasValue)
                    {
                        personnel.Active = personnelItem.active.Value;

                    }
                    else
                    {
                        personnelItem.active = 1;
                    }
                    personnels.Add(personnel);
                }
            }
            return View(personnels);
        }

        public ActionResult RoomPersonnelList()
        {
            List<RoomPersonnel> roomPersonnels = new List<RoomPersonnel>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Oda_Personel.ToList();
                foreach (var roomPersonnelItem in model)
                {
                    RoomPersonnel roomPersonnel = new RoomPersonnel();
                    roomPersonnel.Id = roomPersonnelItem.id;
                    roomPersonnel.Ref_Personnel = roomPersonnelItem.ref_PersonelId;
                    roomPersonnel.Ref_Room = roomPersonnelItem.ref_OdaId;

                    if (roomPersonnelItem.active.HasValue)
                    {
                        roomPersonnel.Active = roomPersonnelItem.active.Value;

                    }
                    else
                    {
                        roomPersonnelItem.active = 1;
                    }
                    roomPersonnels.Add(roomPersonnel);

                }
            }
            return View(roomPersonnels);
        }

        public ActionResult ExamList()
        {
            List<Exam> exams = new List<Exam>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Sinavlars.ToList();
                foreach (var examItem in model)
                {
                    Exam exam = new Exam();
                    exam.Id = examItem.id;
                    exam.Ref_Lecture = examItem.ref_ders;
                    exam.Ref_Personnel = examItem.ref_personel;
                    exam.Status = examItem.durum;
                    exam.Grade = examItem.puan;

                    if (examItem.active.HasValue)
                    {
                        exam.Active = examItem.active.Value;

                    }
                    else
                    {
                        examItem.active = 1;
                    }
                    exams.Add(exam);
                }
            }
            return View(exams);
        }

        public ActionResult TaskList()
        {
            List<Task> tasks = new List<Task>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Rols.ToList();
                foreach (var taskItem in model)
                {
                    Task task = new Task();
                    task.Id = taskItem.id;
                    task.Name = taskItem.adi;
                    task.Authorization = taskItem.yetki;

                    if (taskItem.active.HasValue)
                    {
                        task.Active = taskItem.active.Value;

                    }
                    else
                    {
                        taskItem.active = 1;
                    }

                    tasks.Add(task);

                }
            }
            return View(tasks);
        }

        public ActionResult UserList()
        {
            List<User> users = new List<User>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Kullanicis.ToList();
                foreach (var userItem in model)
                {
                    User user = new User();
                    user.Id = userItem.id;
                    user.Name = userItem.adi;
                    user.Password = userItem.sifre;
                    user.Email = userItem.email;
                    user.Phone = userItem.telefon;
                    user.Ref_Personnel = userItem.ref_Personel;

                    if (userItem.active.HasValue)
                    {
                        user.Active = userItem.active.Value;

                    }
                    else
                    {
                        userItem.active = 1;
                    }
                    users.Add(user);
                }
            }
            return View(users);
        }

        public ActionResult UserTaskList()
        {
            List<UserTask> userTasks = new List<UserTask>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Kullanici_Roller.ToList();
                foreach (var userTaskItem in model)
                {
                    UserTask userTask = new UserTask();
                    userTask.Id = userTaskItem.id;
                    userTask.Ref_User = userTaskItem.Kullanici_ref;
                    userTask.Ref_Task = userTaskItem.Rol_ref;

                    if (userTaskItem.active.HasValue)
                    {
                        userTask.Active = userTaskItem.active.Value;

                    }
                    else
                    {
                        userTaskItem.active = 1;
                    }
                    userTasks.Add(userTask);

                }
            }
            return View(userTasks);
        }

        [Route("Category/{id}/{name}")]
        public ActionResult category(int id, string name)
        {
            ViewBag.id = id;

            Category category = new Category();
            category.Id = id;
            category.Name = name;
            return View(category);
        }



        public ActionResult LoginList()
        {
            List<RegisterViewModel> personnels = new List<RegisterViewModel>();
            using (OkulSistemEntities db = new OkulSistemEntities())
            {
                var model = db.Kullanicis.ToList();
                foreach (var personnelItem in model)
                {
                    RegisterViewModel personnel = new RegisterViewModel();
                    personnel.Username = personnelItem.adi;
                    personnel.Password = personnelItem.sifre;


                    personnels.Add(personnel);
                }
            }
            return View(personnels);
        }

    }
}