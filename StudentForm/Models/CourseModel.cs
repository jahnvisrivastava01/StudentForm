namespace StudentForm.Models
{
    public class Course
    {
        public int  Id { get; set; }
        public string CourseName { get; set; }

        public ICollection<StudentModel> Students { get; set; }

        

       
    }
}
