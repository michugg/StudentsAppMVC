using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAppMVC.Models;
using static StudentsAppMVC.Data.MvcStudentContext;

namespace StudentsAppMVC.Controllers
{
    public class StudentController : Controller
    {

        private static IList<StudentModel> students = new List<StudentModel>()
        {
        new StudentModel(){ StudentId = 1, Name = "Anna", LastName = "Nowak", Age = 19, Email = "test0@wp.pl", IsActive = true },
        new StudentModel(){ StudentId = 2, Name = "Ula", LastName = "Rak", Age = 21, Email = "test1@wp.pl", IsActive = false },
        new StudentModel(){ StudentId = 3, Name = "Ola", LastName = "Kos", Age = 29, Email = "test3@wp.pl", IsActive = false }
        };

        private MvcStudentsContext _dbContext;
        public StudentController(MvcStudentsContext dbContext)
        {
            _dbContext = dbContext;
        }



        // GET: StudentController
        public ActionResult Index()
        {
            return View(_dbContext.Students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var specificStudent = students.FirstOrDefault(x => x.StudentId == id);
            return View(specificStudent);   
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel studentModel)
        {
            _dbContext.Students.Add(studentModel);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var studentToBeDeleted = students.FirstOrDefault(x => x.StudentId == id);
            return View(studentToBeDeleted);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, StudentModel studentModel)
        {
            var studentToBeDeleted = students.FirstOrDefault(x => x.StudentId == id);
            students.Remove(studentToBeDeleted);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult ChangeActiveStatus(int id)
        {
            var specificStudent = students.FirstOrDefault(x => x.StudentId == id);
            specificStudent.IsActive = !specificStudent.IsActive;
            return RedirectToAction("Details", "Student", new { id = specificStudent.StudentId });
        }
    }
}
