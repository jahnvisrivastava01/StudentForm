using StudentForm.Infra;
using StudentForm.Models;
using StudentForm.ViewModel;
using System.Linq;

namespace StudentForm.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context) {
            _context = context;



        }

        public List<Course> GetCourses()
        {
            return _context.Course.ToList();
        }

        public List<CourseSelectionViewModel> GetCourseVMs()
        {
            return _context.Course.Select(CourseSelectionViewModel.ToVM).ToList();
        }

        public void SaveStudent(StudentViewModel vm)
        {
            StudentModel student = new StudentModel()
            {
                Name = vm.Name,
                Email = vm.Email,
                Age = vm.Age,
                EnrollmentId = vm.EnrollmentId,
                Specialisation = vm.Specialisation
            };

            student.Courses = _context.Course.Where(c => vm.Courses.Where(x => x.isSelected).Select(x => x.Id).Contains(c.Id)).ToList();

            _context.Students.Add(student);

            _context.SaveChanges(); 
        }
    }
}

