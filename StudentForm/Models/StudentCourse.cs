namespace StudentForm.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }

        public StudentModel Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
