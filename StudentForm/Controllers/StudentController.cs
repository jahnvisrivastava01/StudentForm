using Microsoft.AspNetCore.Mvc;
using StudentForm.Models;

namespace StudentForm.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Student");
        }

        [HttpPost]

        public IActionResult Index(StudentModel Data)
        {
            if (!ModelState.IsValid)
            {
                return View("Student", Data);
            }
            Data.Message = "Student Details Submitted Successfully!";
            return View ("Student", Data);
        }
    }
}
