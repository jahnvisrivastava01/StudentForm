using System.ComponentModel.DataAnnotations;

namespace StudentForm.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        [StringLength(128, ErrorMessage = "The name should not have 128 or more characters!", MinimumLength =5)]
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public string Course { get; set; }

        public string EnrollmentId { get; set; }

        public string Specialisation { get; set; }

        public string Message { get; set; }

    }
}
