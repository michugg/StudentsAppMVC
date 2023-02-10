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
            var specificStudent = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);
            return View(specificStudent);

        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View(new StudentModel());
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
            var studentToBeEdited = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);
            return View(studentToBeEdited);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentModel studentModel)
        {
            var studentToBeEdited = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);

            studentToBeEdited.Name = studentModel.Name;
            studentToBeEdited.LastName = studentModel.LastName;
            studentToBeEdited.Age = studentModel.Age;
            studentToBeEdited.Email = studentModel.Email;

            _dbContext.Students.Update(studentToBeEdited);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var studentToBeDeleted = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);
            return View(studentToBeDeleted);

        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, StudentModel studentModel)
        {
            var studentToBeDeleted = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);
            _dbContext.Students.Remove(studentToBeDeleted);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult ChangeActiveStatus(int id)
        {
            var specificStudent = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);
            specificStudent.IsActive = !specificStudent.IsActive;
            _dbContext.SaveChanges();
            return RedirectToAction("Details", "Student", new { id = specificStudent.StudentId });
        }

    }
}