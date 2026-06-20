using StudentForm.Models;

namespace StudentForm.ViewModel
{
    public class CourseSelectionViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public bool isSelected { get; set; }

        public static CourseSelectionViewModel ToVM(Course course)
        {
            return new CourseSelectionViewModel()
            {
                CourseName = course.CourseName,
                Id = course.Id,

            };
        }
       
    }
}
