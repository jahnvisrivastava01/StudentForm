using Microsoft.AspNetCore.Mvc;
using StudentForm.Models;
using StudentForm.Services;
using StudentForm.ViewModel;

namespace StudentForm.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            StudentViewModel vm = new StudentViewModel();
            vm.Courses = _studentService.GetCourseVMs();

            return View("Student", vm);
        }

        [HttpPost]

        public IActionResult Index(StudentViewModel Data)
        {
            if (!ModelState.IsValid)
            {
                Data.Courses = _studentService.GetCourseVMs();
                return View("Student", Data);
            }
            _studentService.SaveStudent(Data);
            
            Data.Courses= _studentService.GetCourseVMs();
            return View ("Student", Data);
        }
    }
}
