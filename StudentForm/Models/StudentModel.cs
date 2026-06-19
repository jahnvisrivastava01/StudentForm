using System.ComponentModel.DataAnnotations;


namespace StudentForm.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50,   ErrorMessage = "Name should be between 1 and 50 characters!", MinimumLength =1)]

        
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        public string Email { get; set; }

        [Range(18,28,ErrorMessage = "Age should be between 18 and 28!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Course is Required")]
        public string Course { get; set; }

        [Required(ErrorMessage = "Enrollment ID is Required")]
        
        public string EnrollmentId { get; set; }

        [Required(ErrorMessage = "Specialisation is required")]
        public string Specialisation { get; set; }

        
        public string Message { get; set; }

    }
}
